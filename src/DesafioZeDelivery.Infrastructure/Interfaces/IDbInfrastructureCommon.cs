using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioZeDelivery.Infrastructure.Interfaces
{
    public interface IDbInfrastructureCommon<T>
    {
        Task<IEnumerable<T>> Get();
        Task<IEnumerable<T>> Get(string filter);
    }
}
