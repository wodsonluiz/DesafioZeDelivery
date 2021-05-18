using DesafioZeDelivery.Core.Abstractions;
using DesafioZeDelivery.Core.Models;
using Mongo2Go;
using MongoDB.Driver;

namespace DesafioZeDelivery.Test.Mock
{
    public class ZeDeliveryDatabaseSettingsMock
    {
        private MongoDbRunner _runner;

        private IZeDeliveryDatabaseSettings _settings;

        public ZeDeliveryDatabaseSettingsMock(IZeDeliveryDatabaseSettings settings)
        {
            _settings = settings;
            _runner = MongoDbRunner.Start();
        }

        public IMongoCollection<Partner> ConfigureMock()
        {
            MongoClient client = new MongoClient(_runner.ConnectionString);
            IMongoDatabase database = client.GetDatabase(_settings.DatabaseName);

            var collection = database.GetCollection<Partner>(_settings.ZeDeliveryCollection);

            return collection;
        }
    }
}
