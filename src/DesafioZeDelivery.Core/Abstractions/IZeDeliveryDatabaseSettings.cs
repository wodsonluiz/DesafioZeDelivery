namespace DesafioZeDelivery.Core.Abstractions
{
    public interface IZeDeliveryDatabaseSettings
    {
        string ZeDeliveryCollection { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
