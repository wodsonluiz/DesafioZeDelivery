using DesafioZeDelivery.Abstraction.Interfaces;
using DesafioZeDelivery.Domain.Models.Dto;
using DesafioZeDelivery.Infrastructure.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioZeDelivery.Domain.Service
{
    public class ZeDeliveryService : IZeDeliveryService
    {
        private readonly IMongoCollection<Partner> _mongoCollection;
        private readonly IDbInfrastructureCommon<Partner> _mongo;

        public ZeDeliveryService(IMongoCollection<Partner> mongoCollection, IZeDeliveryDatabaseSettings settings)
        {
            _mongoCollection = mongoCollection;
        }

        public async Task<IEnumerable<Partner>> Get()
        {
            return await _mongo.Get();
        }

        public async Task<IEnumerable<Partner>> GetAddress(double lon, double lat)
        {
            string filter = GenerateQueryFindLocation(lon, lat);
            var addess = await _mongo.Get(filter);
            return addess; 
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

    }
}
