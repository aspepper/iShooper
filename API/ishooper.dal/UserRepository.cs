using System.Linq;
using Ishooper.Dal.Interfaces;
using Ishooper.Dal.Models;
using MongoDB.Driver;

namespace Ishooper.Dal
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public UserRepository(IMongoContext context) : base(context)
        {

        }

        /// <summary>
        /// Retorna a lista de usuários com os parâmetros
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userLogon"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public IQueryable<User> SelectAny(string name, string userLogon, string email)
        {

            var filter = Builders<User>.Filter.Or(
                Builders<User>.Filter.Where(e => e.Name.Contains(name)),
                Builders<User>.Filter.Where(e => e.UserLogon.Contains(userLogon)),
                Builders<User>.Filter.Where(e => e.Email.Equals(email))
                );
            return base.DbSet.Find(filter).ToEnumerable<User>().AsQueryable();
        }

        /// <summary>
        /// Validar acesso de usuários no sistema
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string login, string password)
        {

            var filter = Builders<User>.Filter.And(
                Builders<User>.Filter.Where(e => e.UserLogon.Equals(login)),
                Builders<User>.Filter.Where(e => e.Password.Equals(password)),
                Builders<User>.Filter.Where(e => e.IsDeleted.Equals(false))
                );
            return base.DbSet.Find(filter).ToList<User>().Any();
        }

        /// <summary>
        /// Valida se já existe um usuário o mesmo login cadastrado
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public bool IsUserExistent(string login)
        {
            var filter = Builders<User>.Filter.And(
                Builders<User>.Filter.Where(e => e.UserLogon.Equals(login))
                );
            return base.DbSet.Find(filter).ToList<User>().Any();
        }

        /// <summary>
        /// Valida se já existe um usuário com o mesmo e-mail cadastrado
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsEmailExistent(string email)
        {
            var filter = Builders<User>.Filter.And(
                Builders<User>.Filter.Where(e => e.Email.Equals(email))
                );
            return base.DbSet.Find(filter).ToList<User>().Any();
        }

    }
}
