using System;
using System.Threading.Tasks;
using Ishooper.Dal.Interfaces;

namespace Ishooper.Dal
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoContext _context;

        public UnitOfWork(IMongoContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            var task = Task.Run(async() => await _context.SaveChanges());
            return task.Result > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
