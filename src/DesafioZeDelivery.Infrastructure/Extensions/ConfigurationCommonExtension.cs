using DesafioZeDelivery.Infrastructure.Interfaces;
using DesafioZeDelivery.Infrastructure.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DesafioZeDelivery
{
    public static class ConfigurationCommonExtension
    {
        public static MongoClient GetMongoClient(this IZeDeliveryDatabaseSettings zeDeliveryDatabaseSettings)
        {
            return new MongoClient(zeDeliveryDatabaseSettings.ConnectionString);
        }

        public static IServiceCollection AddConfigurationZeDelivery(this IServiceCollection services, IConfiguration _configuration)
        {
            services.Configure<ZeDeliveryDatabaseSettings>(_configuration.GetSection(nameof(ZeDeliveryDatabaseSettings)));
            services.AddSingleton<IZeDeliveryDatabaseSettings>(sp => sp.GetRequiredService<IOptions<ZeDeliveryDatabaseSettings>>().Value);

            return services;
        }
    }
}
