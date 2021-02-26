using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookTurf.Services.Interfaces
{
    public interface IEntityService<T>
    {
        IEnumerable<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> AddUnitOfWork();
        void AddRange(IEnumerable<T> entity);
        void UpdateRange(IEnumerable<T> entity);
        void DeleteRange(IEnumerable<T> entity);
        bool UnitWork();
    }
}
