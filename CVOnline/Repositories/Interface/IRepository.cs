using CVOnline.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVOnline.Repositories.Interface
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetAsync(int id);
        Task<T> PostAsync(T entity);
        Task<T> PutAsync(T entity);
        Task<T> DeleteAsync(int id);
    }
}
