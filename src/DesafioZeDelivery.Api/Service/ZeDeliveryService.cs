using DesafioZeDelivery.Api.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DesafioZeDelivery.Api.Service
{
    public class ZeDeliveryService : IZeDeliveryService
    {
        private readonly IMongoCollection<SpecificationGeographic> _specificationGeographics;

        public ZeDeliveryService(IZeDeliveryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _specificationGeographics = database.GetCollection<SpecificationGeographic>(settings.ZeDeliveryCollection);
        }

        public List<SpecificationGeographic> Get() => 
            _specificationGeographics.Find(sg => true).ToList();

        public SpecificationGeographic Get(string id) => 
            _specificationGeographics.Find<SpecificationGeographic>(sg => sg.Id == id).FirstOrDefault();

        public SpecificationGeographic Create(SpecificationGeographic specificationGeographic)
        {
            _specificationGeographics.InsertOne(specificationGeographic);
            return specificationGeographic;
        }

        public void Remove(string id) => _specificationGeographics.DeleteOne(sg => sg.Id == id);
    }

    public interface IZeDeliveryService
    {
        List<SpecificationGeographic> Get();
        SpecificationGeographic Get(string id);
        SpecificationGeographic Create(SpecificationGeographic specificationGeographic);
        void Remove(string id);
    }
}
