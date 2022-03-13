using Domain.Entities.Interface;
using Domain.Repositories.Interface.BaseRepositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Abstract
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
    {
        private readonly AppDbContext _dbcontext;

        protected DbSet<T> table;

        public BaseRepository(AppDbContext appDbContext)
        {
            this._dbcontext = appDbContext;
            table = _dbcontext.Set<T>();
        }
        public async Task Add(T entity)
        {
            await table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            // table.Remove(entity); => Böyle yazabilirdim ancak remove yapmak değil passive yapmak istiyorum.
        }

        public async Task<T> GetDefault(Expression<Func<T, bool>> expression)
        {
            return await table.FirstOrDefaultAsync(expression);
        }

        public async Task<List<T>> GetDefaults(Expression<Func<T, bool>> expression) => await table.Where(expression).ToListAsync();

        public void Update(T entity)
        {
           _dbcontext.Entry<T>(entity).State = EntityState.Modified;
        }
    }
}
