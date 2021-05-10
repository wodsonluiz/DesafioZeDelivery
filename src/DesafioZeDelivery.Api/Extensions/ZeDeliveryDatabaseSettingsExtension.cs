using DesafioZeDelivery.Api.Models;
using MongoDB.Driver;

namespace DesafioZeDelivery.Api
{
    public static class IZeDeliveryDatabaseSettingsExtension
    {
        public static IMongoCollection<SpecificationGeographic> Configure(this IZeDeliveryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            var collection = database.GetCollection<SpecificationGeographic>(settings.ZeDeliveryCollection);

            collection.Indexes.CreateOne(
                new CreateIndexModel<SpecificationGeographic>(Builders<SpecificationGeographic>.IndexKeys.Descending(model => model.id),
                new CreateIndexOptions { Unique = true }));

            return collection;
        }
    }
}
