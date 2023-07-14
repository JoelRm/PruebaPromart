
using Microsoft.Extensions.DependencyInjection;
using PruebaPromart.DataAccess.Implementations;
using PruebaPromart.DataAccess.Interfaces;
using PruebaPromart.Services.Implementations;
using PruebaPromart.Services.Interfaces;

namespace PruebaPromart.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddTransient<IClientRepository, ClientRepository>()
                .AddTransient<IClientService, ClientService>();

            return services;
        }
    }
}
