using MongoDB.Bson.Serialization.Attributes;

namespace DesafioZeDelivery.Api.Models
{
    public class GeometryBase
    {
        [BsonElement("type")]
        public string type { get; set; }
    }
}
