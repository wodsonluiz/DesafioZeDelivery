using DesafioZeDelivery.Core.Abstractions;
using DesafioZeDelivery.Core.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioZeDelivery.Core.Service
{
    public class ZeDeliveryService : IZeDeliveryService
    {
        private readonly IMongoCollection<Partner> _mongoCollection;
        private readonly IQueryDataBase _queryDataBase;

        public ZeDeliveryService(IQueryDataBase queryDataBase, IMongoCollection<Partner> mongoCollection)
        {
            _mongoCollection = mongoCollection;
            _queryDataBase = queryDataBase;
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
            string cmdDoc = _queryDataBase.GenerateQueryFindLocation(lon, lat);
            var listResult = _queryDataBase.GetObjects(cmdDoc);
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
    }
}
