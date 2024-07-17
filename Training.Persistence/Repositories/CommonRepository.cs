using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Application.Services;
using Training.Domain.Entities;
using Training.Persistence.DbContexts;

namespace Training.Persistence.Repositories
{
    public class CommonRepository<T> : ICommonRepository<T> where T : class
    {
        private readonly CourseContext _context;
        private bool disposedValue;

        public CommonRepository(CourseContext context)
        {
            _context = context;
        }

        protected DbSet<T> EntitySet
        {
            get
            {
                return _context.Set<T>();
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await EntitySet.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await EntitySet.FindAsync(id);
        }

        public async void Delete(Guid id)
        {
            T entity = await EntitySet.FindAsync(id);
            if (entity != null)
            {
                EntitySet.Remove(entity);
                _context.SaveChangesAsync();
            }
        }

        public async Task Create(T entity)
        {
            EntitySet.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposedValue = true;
            }
        }


        public void Dispose()
        {

            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
