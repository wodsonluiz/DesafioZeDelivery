using DesafioZeDelivery.Infrastructure.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioZeDelivery.Infrastructure.Service
{
    public class DbInfrastructureCommon<T> : IDbInfrastructureCommon<T>
    {
        private readonly IMongoCollection<T> _mongoCollection;

        public DbInfrastructureCommon(IMongoCollection<T> mongoCollection, IZeDeliveryDatabaseSettings settings)
        {
            _mongoCollection = mongoCollection;
        }
        public async Task<IEnumerable<T>> Get()
        {
            return await _mongoCollection.FindAsync(sg => true).Result.ToListAsync();
        }
    }
}
