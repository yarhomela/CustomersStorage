using CustomerStorage.BusinessLogicLayer;
using CustomerStorage.Services.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;

services.AddContext(configuration);
services.SetRepositoryDependencies();
services.SetDependencies();

services.AddControllers();
services.AddMvcCore();

var app = builder.Build();
app.MapGet("/", () => "Hello Page!");
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();



