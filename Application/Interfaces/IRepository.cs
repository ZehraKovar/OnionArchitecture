using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsycc(Expression<Func<T,bool>> exp=null);
        Task<T> GetByIdAsync(Guid id);
        Task CreateAsync(T entity);
        Task Update(T entity);
        Task Remove(T entity);
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> exp);
    }
}
