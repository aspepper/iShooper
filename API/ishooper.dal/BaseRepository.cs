using Ishooper.Dal.Interfaces;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ishooper.Dal
{

    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected IMongoContext _context;
        protected IMongoCollection<TEntity> DbSet;

        protected BaseRepository(IMongoContext context)
        {
            _context = context;
            string collectionName = typeof(TEntity).Name.ToLower();
            DbSet = _context.GetCollection<TEntity>(collectionName);
        }

        public virtual Task Add(TEntity obj)
        {   
            _context.AddCommand(async () => await DbSet.InsertOneAsync(obj));
            return Task.FromResult(0);
        }

        public virtual async Task<TEntity> GetBy(string field, object value)
        {
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq(field, value));
            try
            {
                return data.First();
            }
            catch
            {
                return null;
            }
        }

        public virtual async Task<TEntity> GetById(string id)
        {
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", DBUtils.StringToObjectId(id)));
            return data.FirstOrDefault();
        }

        public virtual async Task<IQueryable<TEntity>> GetAll()
        {
            var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList<TEntity>().AsQueryable<TEntity>();
        }

        public virtual void Update(string id, TEntity obj)
        {
            _context.AddCommand(async () =>
            {   await DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", DBUtils.StringToObjectId(id)), obj); });
        }

        public virtual void Remove(string id) => _context.AddCommand(() => 
            DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", DBUtils.StringToObjectId(id))));

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
