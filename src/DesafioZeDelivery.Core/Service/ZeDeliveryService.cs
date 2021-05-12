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
        private readonly IMongoCollection<Partner> _specificationGeographics;
        private readonly IZeDeliveryDatabaseSettings _settings;
        private readonly IQueryDataBase _queryDataBase;

        public ZeDeliveryService(IZeDeliveryDatabaseSettings settings, IQueryDataBase queryDataBase)
        {
            _specificationGeographics = settings.Configure();
            _settings = settings;
            _queryDataBase = queryDataBase;
        }

        public async Task<List<Partner>> Get()
        {
            try
            {
                return await _specificationGeographics.FindAsync(sg => true).Result.ToListAsync();
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
                return await _specificationGeographics.FindAsync(sg => sg.id == id).Result.FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<bool> Create(Partner partner)
        {
            try
            {
                await _specificationGeographics.InsertOneAsync(partner);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Remove(string id)
        {
            try
            {
                var result = await _specificationGeographics.DeleteOneAsync(sg => sg.id == id);

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
