using DesafioZeDelivery.Core.Abstractions;
using DesafioZeDelivery.Core.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
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
            //FieldDefinition<SpecificationGeographic> field = "coverageArea.coordinates";

            //var point = GeoJson.Point(GeoJson.Geographic(lon, lat));
            //var filter = Builders<SpecificationGeographic>.Filter.Where(sg => sg.coverageArea.coordinates.Where(x => x.Where(xx => xx.Where(xxx => xxx.Where(xxxx => xxxx.Equals(lon)))));

            //var objs = _specificationGeographics.Find(filter).FirstOrDefault();


            return null;
        }

        public async Task<Partner> Get(string id)
        {
            try
            {
                return await _specificationGeographics.FindAsync(sg => sg.id == id).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<Partner> Create(Partner specificationGeographic)
        {
            try
            {
                await _specificationGeographics.InsertOneAsync(specificationGeographic);
                return specificationGeographic;
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
