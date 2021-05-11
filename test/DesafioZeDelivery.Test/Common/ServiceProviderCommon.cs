using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioZeDelivery.Test.Common
{
    public static class ServiceProviderCommon
    {
        public static ServiceProvider Generator()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var services = new ServiceCollection();
            services.AddConfigurationZeDelivery(config);

            return services.BuildServiceProvider();
        }
    }
}
