using MongoDB.Bson.Serialization.Attributes;

namespace DesafioZeDelivery.Core.Models
{
    public class GeometryBase
    {
        [BsonElement("type")]
        public string type { get; set; }
    }
}
