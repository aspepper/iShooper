using System;
namespace Ishooper.Dal.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
