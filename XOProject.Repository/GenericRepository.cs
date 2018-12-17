using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace XOProject.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : class, new()
    {
        protected ExchangeContext DbContext { get; set; }

        public async Task<T> GetAsync(int id)
        {
            return await DbContext.FindAsync<T>(id);
        }

        public IQueryable<T> Query()
        {
            return DbContext.Set<T>().AsQueryable();
        }

        public async Task InsertAsync(T entity)
        {
            DbContext.Set<T>().Add(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }
    }
}