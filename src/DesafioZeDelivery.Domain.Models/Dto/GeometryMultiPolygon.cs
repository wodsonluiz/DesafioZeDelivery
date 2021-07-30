using System.Collections.Generic;

namespace DesafioZeDelivery.Domain.Models.Dto
{
    public class GeometryMultiPolygon : GeometryBase
    {
        public List<List<List<List<double>>>> coordinates { get; set; }
    }
}
