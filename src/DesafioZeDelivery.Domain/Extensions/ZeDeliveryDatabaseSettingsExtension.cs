using DesafioZeDelivery.Domain.Models.Dto;
using DesafioZeDelivery.Infrastructure.Interfaces;
using MongoDB.Driver;

namespace DesafioZeDelivery
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

            collection.Indexes.CreateOne(
                new CreateIndexModel<Partner>(Builders<Partner>.IndexKeys.Descending(model => model.document),
                new CreateIndexOptions { Unique = true }));

            collection.Indexes.CreateOne(
                new CreateIndexModel<Partner>(Builders<Partner>.IndexKeys.Descending(model => model.coverageArea)));

            return collection;
        }
    }
}
