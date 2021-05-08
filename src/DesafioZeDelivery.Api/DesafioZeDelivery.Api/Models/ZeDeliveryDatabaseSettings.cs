namespace DesafioZeDelivery.Api.Models
{
    public class ZeDeliveryDatabaseSettings : IZeDeliveryDatabaseSettings
    {
        public string ZeDeliveryCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IZeDeliveryDatabaseSettings
    {
        string ZeDeliveryCollection { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
