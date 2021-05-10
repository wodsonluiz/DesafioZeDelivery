using MongoDB.Driver.GeoJsonObjectModel;
using System.Collections.Generic;

namespace DesafioZeDelivery.Api.Models
{
    public class GeometryPoint : GeometryBase
    {
        public List<double> coordinates { get; set; }
    }
}
