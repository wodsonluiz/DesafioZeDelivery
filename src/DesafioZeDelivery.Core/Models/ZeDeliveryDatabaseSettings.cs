using DesafioZeDelivery.Core.Abstractions;

namespace DesafioZeDelivery.Core.Models
{
    public class ZeDeliveryDatabaseSettings : IZeDeliveryDatabaseSettings
    {
        public string ZeDeliveryCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
