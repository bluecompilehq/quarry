using System.Text.Json.Serialization;
using Quarry.Api.Endpoints;
using Quarry.Core.Models;
using Quarry.Core.Providers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddKeyedSingleton<IDatabaseProvider, SqliteProvider>(DatabaseKind.Sqlite);
builder.Services.AddKeyedSingleton<IDatabaseProvider, SqlServerProvider>(DatabaseKind.SqlServer);

builder.Services.ConfigureHttpJsonOptions(ops =>
{
    ops.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapQueryEndPoints();



app.Run();

