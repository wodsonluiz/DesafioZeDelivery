using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace DesafioZeDelivery.Api.Models
{
    public class GeometryMultiPolygon : GeometryBase
    {
        [BsonElement("coordinates")]
        public List<List<List<List<double>>>> coordinates { get; set; }
    }
}
