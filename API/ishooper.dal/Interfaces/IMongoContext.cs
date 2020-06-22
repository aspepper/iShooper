using System;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Ishooper.Dal.Interfaces
{
    public interface IMongoContext: IDisposable
    {

        Task<int> SaveChanges();

        IMongoCollection<T> GetCollection<T>(string name);

        void AddCommand(Func<Task> func);

    }
}
