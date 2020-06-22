using System;
using Ishooper.Dal.Interfaces;
using Ishooper.Dal.Models;

namespace Ishooper.Dal
{
    public class ErrorLogRepository : BaseRepository<ErrorLog>, IErrorLogRepository
    {
        public ErrorLogRepository(IMongoContext context) : base(context)
        {
        }
    }
}
