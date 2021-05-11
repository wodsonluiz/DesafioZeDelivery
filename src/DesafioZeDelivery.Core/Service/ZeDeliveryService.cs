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

        public ZeDeliveryService(IZeDeliveryDatabaseSettings settings)
        {
            _specificationGeographics = settings.Configure();
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

        public Partner GetAddress(double lon, double lat)
        {
            List<List<List<List<double>>>> listResult;
            var resutList = _specificationGeographics.FindAsync(sg => sg.address.coordinates.Any()).Result.ToList();

            if (resutList.Count > 0)
            {
                foreach (var item in resutList)
                {

                    //var multiPolygon = item.coverageArea.coordinates;
                }
            }





            return null;
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

        public async Task<Partner> Create(Partner partner)
        {
            try
            {
                await _specificationGeographics.InsertOneAsync(partner);
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
