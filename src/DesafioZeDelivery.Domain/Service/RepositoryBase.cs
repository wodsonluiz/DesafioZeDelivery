using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioZeDelivery.Abstraction.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DesafioZeDelivery.Domain.Service
{
    public abstract class RepositoryBase<TEntity>
    {
        private readonly IMongoCollection<TEntity> _mongoCollection;
        public RepositoryBase()
        {
            
        }

        public async Task Add(TEntity obj)
        {
            await _mongoCollection.InsertOneAsync(obj);
            return;
        }

        public async Task<TEntity> GetId(ObjectId id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);

            return await _mongoCollection.FindSync(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _mongoCollection.FindSync(new BsonDocument()).ToListAsync();
        }

        public async Task Delete(ObjectId id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);

            await _mongoCollection.DeleteOneAsync(filter);
            return;
        }

        public async Task Update(ObjectId id, TEntity obj)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);

            
        }

        
    }
}