using CustomerStorage.Services.Services;
using CustomerStorage.Services.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerStorage.BusinessLogicLayer
{
    public static class DependencyInjection
    {
        public static void SetDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
