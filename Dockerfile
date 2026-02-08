# --- STAGE 1: BASE BUILD ---
FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build-env
WORKDIR /src

# Install Node.js and npm
RUN apk add --no-cache nodejs npm

# 1. Copy package files and install JS dependencies
# Doing this first caches the npm layer separately from C# code
COPY package*.json ./
RUN npm install

# 2. Copy and Restore .NET projects
# Explicitly copy project files first to cache the restore layer
COPY ["THTR.Client.Web/THTR.Client.Web.csproj", "THTR.Client.Web/"]
COPY ["THTR.Persist/THTR.Persist.csproj", "THTR.Persist/"]
COPY ["THTR.Common/THTR.Common.csproj", "THTR.Common/"]

RUN dotnet restore "THTR.Client.Web/THTR.Client.Web.csproj"

# 3. Copy all source code 
# !! CRITICAL: Ensure your .dockerignore excludes bin/ and obj/ to fix the MSB4018 error !!
COPY . .

# --- STAGE 2: TARGET WEB ---
FROM build-env AS publish-web
ENV BuildingInsideDocker=true

# ** ADD THIS: Run esbuild to create minified files BEFORE publishing **
RUN npm run build-js

# Run the publish
RUN dotnet publish "THTR.Client.Web/THTR.Client.Web.csproj" -c Release -o /app/web

# DELETE source JS files physically from the publish directory
RUN rm -rf /app/web/wwwroot/js/classes \
    && rm -rf /app/web/wwwroot/js/modals \
    && rm -f /app/web/wwwroot/js/THTR.main.js

# --- STAGE 3: TARGET PERSIST ---
FROM build-env AS publish-persist
RUN dotnet publish "THTR.Persist/THTR.Persist.csproj" -c Release -o /app/persist

# --- FINAL RUNTIME: WEB ---
FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS web-runtime
WORKDIR /app
COPY --from=publish-web /app/web .
ENV ASPNETCORE_HTTP_PORTS=8080
ENTRYPOINT ["dotnet", "THTR.Client.Web.dll"]

# --- FINAL RUNTIME: PERSIST ---
FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS persist-runtime
WORKDIR /app
COPY --from=publish-persist /app/persist .
ENV ASPNETCORE_HTTP_PORTS=8080
ENTRYPOINT ["dotnet", "THTR.Persist.dll"]