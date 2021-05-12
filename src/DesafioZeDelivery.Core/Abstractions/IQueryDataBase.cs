using DesafioZeDelivery.Core.Models;
using System.Collections.Generic;

namespace DesafioZeDelivery.Core.Abstractions
{
    public interface IQueryDataBase
    {
        string GenerateQueryFindLocation(double x, double y);
        List<Partner> GetObjects(string filterCmd);
    }
}
