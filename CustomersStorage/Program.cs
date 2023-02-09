using CustomerStorage.BusinessLogicLayer;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

var configuration = builder.Configuration;
var services = builder.Services;
var appSettings = configuration.GetSection("ApplicationSettings");

services.AddContext(appSettings);




