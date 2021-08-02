using DesafioZeDelivery.Infrastructure.Interfaces;

namespace DesafioZeDelivery.Infrastructure.Service
{
    public class ZeDeliveryDatabaseSettings : IZeDeliveryDatabaseSettings
    {
        public string ZeDeliveryCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
