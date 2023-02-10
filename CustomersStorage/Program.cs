using CustomerStorage.BusinessLogicLayer;
using CustomerStorage.Services.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;

services.AddContext(configuration);
services.SetRepositoryDependencies();
services.SetDependencies();

var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.Run();



