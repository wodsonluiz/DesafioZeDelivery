using System.Collections.Generic;

namespace DesafioZeDelivery.Api.Models
{
    public class GeometryMultiPolygon : GeometryBase
    {
        public List<List<List<string>>> coordinates { get; set; }
    }
}
