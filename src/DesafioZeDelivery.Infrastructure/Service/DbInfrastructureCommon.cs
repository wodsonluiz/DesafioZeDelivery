using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioZeDelivery.Infrastructure.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace DesafioZeDelivery.Infrastructure.Service
{
    public class DbInfrastructureCommon<T> : IDbInfrastructureCommon<T>
    {
        private readonly IMongoCollection<T> _mongoCollection;
        private readonly IZeDeliveryDatabaseSettings _settings;

        public async Task<IEnumerable<T>> Get()
        {
            return await _mongoCollection.FindAsync(sg => true).Result.ToListAsync();
        }

        public async Task<IEnumerable<T>> Get(string filter)
        {
            var mongoClient = _settings.GetMongoClient();
            var db = mongoClient.GetDatabase(_settings.DatabaseName);

            var cmd = new JsonCommand<BsonDocument>(filter);
            var response = await db.RunCommandAsync(cmd);

            var obj = response[0]["firstBatch"];
            return JsonConvert.DeserializeObject<List<T>>(obj.ToJson());
        }

        
    }
}
