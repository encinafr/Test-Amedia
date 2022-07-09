using ApiTest.EF.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiTest.EF.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationContext _context;
        public Repository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<int?> Add(List<SqlParameter> parameters, string sql)
        {
           return await _context.Database.ExecuteSqlRawAsync(sql, parameters.ToArray()); 
        }

        public void AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAll(string sql)
        {
            return await _context.Set<T>().FromSqlRaw<T>(sql).ToListAsync(); 
        }

        public async Task<T> GetBy(string sql, Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FromSqlRaw<T>(sql).Where(expression).FirstOrDefaultAsync();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        } 
        
        public void Update(string sql, List<SqlParameter> parameters)
        {
            _context.Database.ExecuteSqlRawAsync(sql, parameters.ToArray());
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
