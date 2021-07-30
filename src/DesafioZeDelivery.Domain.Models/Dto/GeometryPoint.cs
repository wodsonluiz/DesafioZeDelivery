using System.Collections.Generic;

namespace DesafioZeDelivery.Domain.Models.Dto
{
    public class GeometryPoint : GeometryBase
    {
        public List<double> coordinates { get; set; }
    }
}
