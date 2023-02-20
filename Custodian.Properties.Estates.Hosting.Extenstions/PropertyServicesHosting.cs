using Custodian.Properties.Estate.Services.Abstraction;
using Custodian.Properties.Estates.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Custodian.Properties.Estates.Hosting.Extenstions
{
    public static class PropertyServicesHosting
    {
        public static IServiceCollection AddUpdcFmDomainServices(this IServiceCollection services, string constring)
        {
            services.AddScoped<IResidentServices, ResidentServices>(s =>
            {
                var serviceInstance = new ResidentServices(constring);

                return serviceInstance;
            });

            services.AddScoped<IAdminServices, AdminServices>(s =>
            {
                var serviceInstance = new AdminServices(constring);
                return serviceInstance;
            });

            return services;
        }
    }
}
