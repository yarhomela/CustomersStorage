using CustomerStorage.DataAccessLayer.Repositories;
using CustomerStorage.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerStorage.Services.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void SetRepositoryDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
