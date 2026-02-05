# --- STAGE 1: BASE BUILD ---
# We do the heavy lifting (restore/build) once for everything
FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build-env
WORKDIR /src

# Copy all .csproj files to restore dependencies (caches this layer)
COPY ["THTR.Client.Web/THTR.Client.Web.csproj", "THTR.Client.Web/"]
COPY ["THTR.Persist/THTR.Persist.csproj", "THTR.Persist/"]
COPY ["THTR.Common/THTR.Common.csproj", "THTR.Common/"]

RUN dotnet restore "THTR.Client.Web/THTR.Client.Web.csproj"

# Copy all source code
COPY . .

# --- STAGE 2: TARGET WEB ---
FROM build-env AS publish-web
RUN dotnet publish "THTR.Client.Web/THTR.Client.Web.csproj" -c Release -o /app/web

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