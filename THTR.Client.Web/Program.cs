using Microsoft.Extensions.Options;
using THTR.Client.Web.Hubs;
using THTR.Common.HttpClients;
using THTR.Common.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add this with your other service registrations
builder.Services.AddSignalR()
    .AddMessagePackProtocol();

builder.Services.Configure<THTRClientOptions>(
    builder.Configuration.GetSection("THTR"));

builder.Services.AddHttpClient();
builder.Services.AddSingleton<PersistHttpClient>(service_provider =>
{
    var http_client_factory = service_provider.GetRequiredService<IHttpClientFactory>();
    var http_client = http_client_factory.CreateClient();

    var thtr_options = service_provider.GetRequiredService<IOptions<THTRClientOptions>>().Value;
    var base_url = thtr_options.PersistUrl; // or whatever your property name is

    return new PersistHttpClient(http_client, base_url);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


// Add this with your other endpoint mappings (after app.MapControllerRoute)
app.MapHub<POCHub>("/poctick");


app.Run();
