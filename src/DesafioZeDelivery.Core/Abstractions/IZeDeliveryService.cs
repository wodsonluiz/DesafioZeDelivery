using DesafioZeDelivery.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioZeDelivery.Core.Abstractions
{
    public interface IZeDeliveryService
    {
        Task<List<Partner>> Get();
        List<Partner> GetAddress(double lon, double lat);
        Task<Partner> Get(string id);
        Task<Partner> Create(Partner specificationGeographic);
        Task<bool> Remove(string id);
    }
}
