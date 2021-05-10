using DesafioZeDelivery.Core.Abstractions;
using DesafioZeDelivery.Core.Models;
using GeoJSON.Net.Geometry;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioZeDelivery.Core.Service
{
    public class ZeDeliveryService : IZeDeliveryService
    {
        private readonly IMongoCollection<SpecificationGeographic> _specificationGeographics;

        public ZeDeliveryService(IZeDeliveryDatabaseSettings settings)
        {
            _specificationGeographics = settings.Configure();
        }

        public List<SpecificationGeographic> Get()
        {
            try
            {
                return _specificationGeographics.Find(sg => true).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SpecificationGeographic GetAddress(double lon, double lat)
        {
            //FieldDefinition<SpecificationGeographic> field = "coverageArea.coordinates";

            //var point = GeoJson.Point(GeoJson.Geographic(lon, lat));
            //var filter = Builders<SpecificationGeographic>.Filter.Where(sg => sg.coverageArea.coordinates.Where(x => x.Where(xx => xx.Where(xxx => xxx.Where(xxxx => xxxx.Equals(lon)))));

            //var objs = _specificationGeographics.Find(filter).FirstOrDefault();


            return null;
        }

        public SpecificationGeographic Get(string id)
        {
            try
            {
                return _specificationGeographics.Find(sg => sg.id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public SpecificationGeographic Create(SpecificationGeographic specificationGeographic)
        {
            try
            {
                _specificationGeographics.InsertOne(specificationGeographic);
                return specificationGeographic;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public void Remove(string id)
        {
            try
            {
                _specificationGeographics.DeleteOne(sg => sg.id == id);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }

    public static class ClassTest
    {

        public static bool FindTest(this GeometryMultiPolygon geometryMultiPolygon)
        {
            var multiPolygon = new MultiPolygon(geometryMultiPolygon.coordinates);


            return false;
        }
    }
}
