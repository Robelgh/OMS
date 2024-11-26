using Application.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly OMSDbContext _context;

        public GenericRepository(OMSDbContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task<bool> Exists(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }



        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }


        public async Task Update(T entity)
        {

            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public void DetachEntity(T entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Detached;
            }
        }


    }
}
