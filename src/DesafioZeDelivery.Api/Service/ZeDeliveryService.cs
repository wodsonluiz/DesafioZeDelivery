using DesafioZeDelivery.Api.Abstractions;
using DesafioZeDelivery.Api.Models;
using GeoJSON.Net.Geometry;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioZeDelivery.Api.Service
{
    public class ZeDeliveryService : IZeDeliveryService
    {
        private readonly IMongoCollection<SpecificationGeographic> _specificationGeographics;

        public ZeDeliveryService(IZeDeliveryDatabaseSettings settings)
        {
            _specificationGeographics = settings.Configure();
        }

        public List<SpecificationGeographic> Get() =>
            _specificationGeographics.Find(sg => true).ToList();

        public SpecificationGeographic GetAddress(double lon, double lat)
        {
            FieldDefinition<SpecificationGeographic> field = "coverageArea.coordinates";

            var point = GeoJson.Point(GeoJson.Geographic(lon, lat));
            var filter = Builders<SpecificationGeographic>.Filter.Where(sg => sg.coverageArea.coordinates.Where(x => x.Where(xx => xx.Where(xxx => xxx.Where(xxxx => xxxx.Equals(lon)))));

            var objs = _specificationGeographics.Find(filter).FirstOrDefault();


            return null;
        }

        public SpecificationGeographic Get(string id) =>
            _specificationGeographics.Find(sg => sg.id == id).FirstOrDefault();

        public SpecificationGeographic Create(SpecificationGeographic specificationGeographic)
        {
            _specificationGeographics.InsertOne(specificationGeographic);
            return specificationGeographic;
        }

        public void Remove(string id) => _specificationGeographics.DeleteOne(sg => sg.id == id);
    }

    public static class ClassTest{

        public static bool FindTest(this GeometryMultiPolygon geometryMultiPolygon)
        {
            var multiPolygon = new MultiPolygon(geometryMultiPolygon.coordinates);


            return false;
        }
    }
}
