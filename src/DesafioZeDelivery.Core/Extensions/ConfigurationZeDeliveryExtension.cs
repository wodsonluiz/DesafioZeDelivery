using DesafioZeDelivery.Core.Abstractions;
using DesafioZeDelivery.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DesafioZeDelivery
{
    public static class ConfigurationZeDeliveryExtension
    {
        public static IServiceCollection AddConfigurationZeDelivery(this IServiceCollection services, IConfiguration _configuration)
        {
            services.Configure<ZeDeliveryDatabaseSettings>(_configuration.GetSection(nameof(ZeDeliveryDatabaseSettings)));
            services.AddSingleton<IZeDeliveryDatabaseSettings>(sp => sp.GetRequiredService<IOptions<ZeDeliveryDatabaseSettings>>().Value);

            return services;
        }
    }
}
