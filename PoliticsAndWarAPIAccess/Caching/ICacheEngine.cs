using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.Caching
{
    public interface ICacheEngine<T> where T : CacheModel
    {
        Task<bool> Build(IEnumerable<T> entities);
        Task<long> Build(T entity);
        void DeleteFromCache(Expression<Func<T, bool>> expr);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expr);
        Task<IEnumerable<T>> FindAsync(string collectionName, Expression<Func<T, bool>> expr);
        IEnumerable<T> Get(Expression<Func<T, bool>> expr);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> GetMaxId();
    }
}