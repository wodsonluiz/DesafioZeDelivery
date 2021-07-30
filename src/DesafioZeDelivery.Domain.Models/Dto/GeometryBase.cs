using MongoDB.Bson.Serialization.Attributes;

namespace DesafioZeDelivery.Domain.Models.Dto
{
    public class GeometryBase
    {
        [BsonElement("type")]
        public string type { get; set; }
    }
}
