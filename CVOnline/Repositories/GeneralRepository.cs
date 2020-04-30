using CVOnline.Bases;
using CVOnline.Context;
using CVOnline.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVOnline.Repositories
{
    public class GeneralRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private readonly MyContext _myContext;

        public GeneralRepository(MyContext myContext)
        {
            _myContext = myContext;
        }

        public async Task<TEntity> DeleteAsync(int id)
        {
            var entity = await _myContext.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }
            _myContext.Set<TEntity>().Remove(entity);
            await _myContext.SaveChangesAsync();
            return entity;


            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            var result = await _myContext.Set<TEntity>().ToListAsync();
            return result;

            //throw new NotImplementedException();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _myContext.Set<TEntity>().FindAsync(id);

            //throw new NotImplementedException();
        }

        public async Task<TEntity> PostAsync(TEntity entity)
        {
            await _myContext.Set<TEntity>().AddAsync(entity);
            await _myContext.SaveChangesAsync();
            return entity;

            //throw new NotImplementedException();
        }

        public async Task<TEntity> PutAsync(TEntity entity)
        {
            _myContext.Entry(entity).State = EntityState.Modified;
            await _myContext.SaveChangesAsync();
            return entity;

            //throw new NotImplementedException();
        }
    }
}
