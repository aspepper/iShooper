using System;
using System.Collections.Generic;
using System.Linq;
using Ishooper.Dal.Interfaces;
using Ishooper.Dal.Models;
using MongoDB.Driver;

namespace Ishooper.Dal
{
    public class ProfessionRepository : BaseRepository<Profession>, IProfessionRepository
    {
        public ProfessionRepository(IMongoContext context) : base(context)
        {

        }

        public IQueryable<Profession> GetList(FilterDefinition<Profession> filter)
        {
            return base.DbSet.Find(filter).ToList<Profession>().AsQueryable();
        }

        public IQueryable<Profession> GetComercialList()
        {
            var filter = Builders<Profession>.Filter.And(
                Builders<Profession>.Filter.Where(e => e.Administrative.Equals(false)),
                Builders<Profession>.Filter.Where(e => e.Status.Equals(true))
                );

            return GetList(filter);
        }

        public IQueryable<Profession> GetAdminList()
        {
            var filter = Builders<Profession>.Filter.And(
                Builders<Profession>.Filter.Where(e => e.Administrative.Equals(true)),
                Builders<Profession>.Filter.Where(e => e.Status.Equals(true))
                );

            return GetList(filter);
        }

        public IEnumerable<Profession> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
