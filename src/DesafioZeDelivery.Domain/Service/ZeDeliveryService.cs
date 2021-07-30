using DesafioZeDelivery.Abstraction.Interfaces;
using DesafioZeDelivery.Abstraction.Interfaces.Settings;
using DesafioZeDelivery.Domain.Models.Dto;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioZeDelivery.Domain.Service
{
    public class ZeDeliveryService : IZeDeliveryService
    {
        private readonly IMongoCollection<Partner> _mongoCollection;
        private readonly IZeDeliveryDatabaseSettings _settings;

        public ZeDeliveryService(IMongoCollection<Partner> mongoCollection, IZeDeliveryDatabaseSettings settings)
        {
            _mongoCollection = mongoCollection;
            _settings = settings;
        }

        public async Task<List<Partner>> Get()
        {
            return await _mongoCollection.FindAsync(sg => true).Result.ToListAsync();
        }

        public List<Partner> GetAddress(double lon, double lat)
        {
            string cmdDoc = GenerateQueryFindLocation(lon, lat);
            var listResult = GetObjects(cmdDoc);
            var listFiler = listResult.Where(p => p.address.coordinates != null ? p.address.coordinates.Any() : false);

            return listFiler.ToList();
        }

        public async Task<Partner> Get(string id)
        {
            return await _mongoCollection.FindAsync(sg => sg.id == id).Result.FirstOrDefaultAsync();
        }

        public async Task<Partner> Create(Partner partner)
        {
            await _mongoCollection.InsertOneAsync(partner);
            return partner;
        }

        public async Task<bool> Remove(string id)
        {
            var result = await _mongoCollection.DeleteOneAsync(sg => sg.id == id);

            return result.DeletedCount > 0 ? true : false;
        }

        private string GenerateQueryFindLocation(double x, double y)
        {
            return @"{
			find: 'DesafioZeDelivery',
            filter: { coverageArea: { $geoIntersects: { $geometry: { 'type' : 'Point', 'coordinates' : [ " + x + ", " + y + " ] } } } }}";
        }

        private List<Partner> GetObjects(string filterCmd)
        {
            var mongoClient = _settings.GetMongoClient();
            var db = mongoClient.GetDatabase(_settings.DatabaseName);
            var cmd = new JsonCommand<BsonDocument>(filterCmd);
            var response = db.RunCommand(cmd);

            var obj = response[0]["firstBatch"];
            return JsonConvert.DeserializeObject<List<Partner>>(obj.ToJson());
        }
    }
}
