using DesafioZeDelivery.Core.Abstractions;
using DesafioZeDelivery.Core.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DesafioZeDelivery.Core.Common
{
    public class QueryDataBase : IQueryDataBase
    {
        private readonly IMongoClient _mongoClient;
        private readonly IZeDeliveryDatabaseSettings _settings;
        public QueryDataBase(IZeDeliveryDatabaseSettings settings)
        {
            _mongoClient = settings.GetMongoClient();
            _settings = settings;
        }
        public string GenerateQueryFindLocation(double x, double y)
        {
            return @"{
			find: 'DesafioZeDelivery',
            filter: { coverageArea: { $geoIntersects: { $geometry: { 'type' : 'Point', 'coordinates' : [ " + x + ", " + y + " ] } } } }}";
        }

        public List<Partner> GetObjects(string filterCmd)
        {
            try
            {
                var db = _mongoClient.GetDatabase(_settings.DatabaseName);
                var cmd = new JsonCommand<BsonDocument>(filterCmd);
                var response = db.RunCommand(cmd);

                var obj = response[0]["firstBatch"];
                return JsonConvert.DeserializeObject<List<Partner>>(obj.ToJson());
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
