using CustomersStorage.Middlewares;
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

services.AddCors(config =>
{
    config.AddPolicy("policy",
    builder => builder
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .SetIsOriginAllowed((host) => true)
    );
});

var app = builder.Build();
app.UseExceptionHandler("/Home/Error");
app.UseStaticFiles();
app.UseHttpStatusCodeExceptionMiddleware();
app.UseRouting();
app.UseCors("policy");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();



