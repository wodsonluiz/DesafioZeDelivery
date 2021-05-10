using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace DesafioZeDelivery.Core.Models
{
    public class GeometryMultiPolygon : GeometryBase
    {
        [BsonElement("coordinates")]
        public List<List<List<List<double>>>> coordinates { get; set; }
    }
}
