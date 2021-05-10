using DesafioZeDelivery.Core.Abstractions;
using DesafioZeDelivery.Core.Models;
using MongoDB.Driver;

namespace DesafioZeDelivery.Core
{
    public static class IZeDeliveryDatabaseSettingsExtension
    {
        public static IMongoCollection<Partner> Configure(this IZeDeliveryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            var collection = database.GetCollection<Partner>(settings.ZeDeliveryCollection);

            collection.Indexes.CreateOne(
                new CreateIndexModel<Partner>(Builders<Partner>.IndexKeys.Descending(model => model.id),
                new CreateIndexOptions { Unique = true }));

            return collection;
        }
    }
}
