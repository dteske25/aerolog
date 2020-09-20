using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Aerolog.Core;
using MongoDB.Driver;

namespace Aerolog.Accessors
{
    public interface IBaseMongoAccessor<T> where T : IBaseMongoObject
    {
        Task<bool> Contains(Expression<Func<T, bool>> where);
        Task<long> Count(Expression<Func<T, bool>> where);
        Task Delete(Expression<Func<T, bool>> where);
        Task DeleteById(string id);
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetByIds(IEnumerable<string> ids);
        Task<T> GetById(string id);
        Task<IEnumerable<T>> GetByFilter(FilterDefinition<T> filter);
        Task<T> Insert(T entity);
        Task InsertMany(IEnumerable<T> entities);
        Task<T> Update(T entity);
        Task<T> Save(T entity);
    }
}
