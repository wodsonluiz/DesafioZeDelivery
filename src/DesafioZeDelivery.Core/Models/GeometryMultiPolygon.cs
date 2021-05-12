using System.Collections.Generic;

namespace DesafioZeDelivery.Core.Models
{
    public class GeometryMultiPolygon : GeometryBase
    {
        public List<List<List<List<double>>>> coordinates { get; set; }
    }
}
