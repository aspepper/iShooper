using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ishooper.Dal.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {

        Task Add(TEntity obj);

        Task<TEntity> GetById(string id);
           
        Task<IQueryable<TEntity>> GetAll();

        void Update(string id, TEntity obj);

        void Remove(string id);

    }

}
