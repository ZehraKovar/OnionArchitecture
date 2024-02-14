using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly OnionContext _context;
        public DbSet<T> table => _context.Set<T>();
        public Repository(OnionContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(T entity)
        {
            table.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<T>> GetAllAsycc(Expression<Func<T, bool>> exp=null)
        {
            var query = table.AsQueryable();
            if (exp != null)
            {
                query = query.Where(exp);
            }
            return query;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await table.FindAsync(id);
        }

        public async Task Remove(T entity)
        {
            table.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            table.Update(entity);
            await _context.SaveChangesAsync();
        }

        public Task<T?> GetByFilterAsync(Expression<Func<T, bool>> exp)
        {
            return table.SingleOrDefaultAsync(exp);
        }
    }
}
