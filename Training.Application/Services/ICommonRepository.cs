using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Domain.Entities;

namespace Training.Application.Services
{
    public interface ICommonRepository<T>: IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        void Delete(Guid id);
        Task Create(T entity);
        Task Update(T entity);
    }
}
