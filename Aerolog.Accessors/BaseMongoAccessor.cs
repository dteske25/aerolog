using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Aerolog.Accessors.Infrastructure;
using Aerolog.Core;
using MongoDB.Driver;

namespace Aerolog.Accessors
{
    public abstract class BaseMongoAccessor<T> : IBaseMongoAccessor<T> where T : IBaseMongoObject
    {
        public IMongoCollection<T> Collection { get; }
        public BaseMongoAccessor(MongoContext context)
        {
            Collection = context.Database.GetCollection<T>(typeof(T).Name);
        }

        public virtual async Task<bool> Contains(Expression<Func<T, bool>> where)
        {
            return await Collection.Find(where).AnyAsync();
        }

        public virtual async Task<long> Count(Expression<Func<T, bool>> where)
        {
            return await Collection.CountDocumentsAsync(where);
        }

        public virtual async Task Delete(Expression<Func<T, bool>> where)
        {
            await Collection.DeleteManyAsync(where);
        }

        public virtual async Task DeleteById(string id)
        {
            await Collection.DeleteOneAsync(f => f.Id == id);
        }

        public virtual async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> where)
        {
            var results = await Collection.Find(where).ToListAsync();
            return results;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var results = await Collection.Find(FilterDefinition<T>.Empty).ToListAsync();
            return results;
        }

        public virtual async Task<IEnumerable<T>> GetByIds(IEnumerable<string> ids)
        {
            var query = Builders<T>.Filter.In(t => t.Id, ids);
            var results = await Collection.Find(query).ToListAsync();
            return results;
        }

        public virtual async Task<T> GetById(string id)
        {
            var result = await Collection.Find(f => f.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public virtual async Task<IEnumerable<T>> GetByFilter(FilterDefinition<T> filter)
        {
            var results = await Collection.Find(filter).ToListAsync();
            return results;
        }

        public virtual async Task<T> Insert(T entity)
        {
            await Collection.InsertOneAsync(entity);
            return entity;
        }

        public virtual async Task InsertMany(IEnumerable<T> entities)
        {
            await Collection.InsertManyAsync(entities);
        }

        public virtual async Task<T> Update(T entity)
        {
            await Collection.ReplaceOneAsync(e => e.Id == entity.Id, entity);
            return entity;
        }

        public virtual async Task<T> Save(T entity)
        {
            if (entity.Id == null)
            {
                await Insert(entity);
            }
            else
            {
                await Update(entity);
            }
            return entity;
        }
    }
}
