using Npgsql;
using System.Data;
using THTR.Common.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.Configure<THTRClientOptions>(
    builder.Configuration.GetSection("THTR"));

var connectionString = builder.Configuration["THTR:PostGreSConnectionString"];

builder.Services.AddScoped<IDbConnection>(sp =>
    new NpgsqlConnection(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
