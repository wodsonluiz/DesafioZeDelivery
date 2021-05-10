using DesafioZeDelivery.Api.Models;
using System.Collections.Generic;

namespace DesafioZeDelivery.Api.Abstractions
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
