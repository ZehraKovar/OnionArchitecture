using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsycc();
        Task<T> GetByIdAsync(Guid id);
        Task CreateAsync(T entity);
        Task Update(T entity);
        Task Remove(T entity);
    }
}
