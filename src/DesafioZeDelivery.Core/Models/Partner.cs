using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DesafioZeDelivery.Core.Models
{
    public class Partner
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; private set; }
        [BsonElement("id")]
        public string id { get; set; }
        [BsonElement("tradingName")]
        public string tradingName { get; set; }
        [BsonElement("ownerName")]
        public string ownerName { get; set; }
        [BsonElement("document")]
        public string document { get; set; }
        [BsonElement("coverageArea")]
        public GeoJSON.Net.Geometry.MultiPolygon coverageArea { get; set; }
        [BsonElement("address")]
        public GeometryPoint address { get; set; }
    }
}
