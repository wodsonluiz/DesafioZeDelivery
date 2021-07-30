using DesafioZeDelivery.Abstraction.Interfaces.Settings;

namespace DesafioZeDelivery.Domain.Service.Settings
{
    public class ZeDeliveryDatabaseSettings : IZeDeliveryDatabaseSettings
    {
        public string ZeDeliveryCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
