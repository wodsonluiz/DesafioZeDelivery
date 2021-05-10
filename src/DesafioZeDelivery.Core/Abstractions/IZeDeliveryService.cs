using DesafioZeDelivery.Core.Models;
using System.Collections.Generic;

namespace DesafioZeDelivery.Core.Abstractions
{
    public interface IZeDeliveryService
    {
        List<SpecificationGeographic> Get();
        SpecificationGeographic GetAddress(double lon, double lat);
        SpecificationGeographic Get(string id);
        SpecificationGeographic Create(SpecificationGeographic specificationGeographic);
        void Remove(string id);
    }
}
