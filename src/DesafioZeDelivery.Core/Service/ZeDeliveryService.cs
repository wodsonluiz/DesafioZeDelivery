using DesafioZeDelivery.Core.Abstractions;
using DesafioZeDelivery.Core.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioZeDelivery.Core.Service
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
            try
            {
                return await _mongoCollection.FindAsync(sg => true).Result.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Partner> GetAddress(double lon, double lat)
        {
            string cmdDoc = GenerateQueryFindLocation(lon, lat);
            var listResult = GetObjects(cmdDoc);
            var listFiler = listResult.Where(p => p.address.coordinates != null ?  p.address.coordinates.Any() : false);

            return listFiler.ToList();
        }

        public async Task<Partner> Get(string id)
        {
            try
            {
                return await _mongoCollection.FindAsync(sg => sg.id == id).Result.FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Partner> Create(Partner partner)
        {
            try
            {
                await _mongoCollection.InsertOneAsync(partner);
                return partner;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Remove(string id)
        {
            try
            {
                var result = await _mongoCollection.DeleteOneAsync(sg => sg.id == id);

                if (result.DeletedCount > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string GenerateQueryFindLocation(double x, double y)
        {
            return @"{
			find: 'DesafioZeDelivery',
            filter: { coverageArea: { $geoIntersects: { $geometry: { 'type' : 'Point', 'coordinates' : [ " + x + ", " + y + " ] } } } }}";
        }

        private List<Partner> GetObjects(string filterCmd)
        {
            try
            {
                var mongoClient = _settings.GetMongoClient();
                var db = mongoClient.GetDatabase(_settings.DatabaseName);
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
