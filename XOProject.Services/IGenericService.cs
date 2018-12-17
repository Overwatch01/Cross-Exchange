using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XOProject.Services
{
    public interface IGenericService<T>
    {
        Task<IList<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);
    }
}
