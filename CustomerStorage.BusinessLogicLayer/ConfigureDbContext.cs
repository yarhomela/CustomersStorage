using CustomerStorage.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerStorage.BusinessLogicLayer
{
    public static class ConfigureDbContext
    {
        public static void AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultConection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(defaultConection,
                opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds)));
        }
    }
}