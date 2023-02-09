using CustomerStorage.BusinessLogicLayer;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;

services.AddContext(configuration);

var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.Run();



