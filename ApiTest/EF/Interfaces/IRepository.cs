using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiTest.EF.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetBy(string sql, Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAll(string sql);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
        Task<int?> Add(List<SqlParameter> sqlParameters, string sql);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void Update(string sql, List<SqlParameter> parameters);
        void RemoveRange(IEnumerable<T> entities);
    }
}
