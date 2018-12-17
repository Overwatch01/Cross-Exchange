using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XOProject.Repository;

namespace XOProject.Services
{
    public abstract class GenericService<T> : IGenericService<T>
        where T : class, new()
    {
        protected GenericService(IGenericRepository<T> entityRepository)
        {
            EntityRepository = entityRepository;
        }

        protected IGenericRepository<T> EntityRepository { get; }

        public async Task InsertAsync(T entity)
        {
            await EntityRepository.InsertAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await EntityRepository.UpdateAsync(entity);
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await EntityRepository.Query().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await EntityRepository.GetAsync(id);
        }
    }
}
