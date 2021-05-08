using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DesafioZeDelivery.Api.Models
{
    public class SpecificationGeographic
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string tradingName { get; set; }
        public string ownerName { get; set; }
        public string document { get; set; }
        public object coverageArea { get; set; }
        public object address { get; set; }
    }
}
