using DesafioZeDelivery.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioZeDelivery.Core.Abstractions
{
    public interface IZeDeliveryService
    {
        Task<List<SpecificationGeographic>> Get();
        SpecificationGeographic GetAddress(double lon, double lat);
        Task<SpecificationGeographic> Get(string id);
        Task<SpecificationGeographic> Create(SpecificationGeographic specificationGeographic);
        Task Remove(string id);
    }
}
