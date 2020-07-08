using data = Ishooper.Dal;
using Ishooper.Infra.Interfaces;
using Ishooper.Infra.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using Ishooper.Dal;
using Ishooper.Infra.Extensions;
using Ishooper.Infra.CustomExceptions;

namespace Ishooper.Infra
{
    public class UserService : IUserService
    {

        private readonly IConfiguration _configuration;

        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public User GetById(string id)
        {
            var context = new MongoContext(_configuration);
            var userRec = new data.UserRepository(context);

            var user = userRec.GetById(id).Result;

            return new User
            {
                Id = user.Id.ToString(),
                Name = user.Name,
                UserLogon = user.UserLogon,
                Email = user.Email,
                Telephone = user.Telephone,
                Gender = user.Gender,
                UrlPhoto = user.Photo,
                Profile = user.Profile,
                Occupation = new Profession
                {
                    Id = user.Occupation.Id.ToString(),
                    Description = user.Occupation.Description,
                    Status = user.Occupation.Status,
                    Administrative = user.Occupation.Administrative,
                    CreatedDate = user.Occupation.CreatedDate,
                    ModifiedDate = user.Occupation.ModifiedDate
                }
            };
        }

        public List<User> SelectAny(string name, string userLogon, string email)
        {
            using var context = new MongoContext(_configuration);
            using var userRec = new data.UserRepository(context);
            string key = _configuration.GetSection("key").Value;

            List<User> listRetorno = new List<User>();
            foreach (data.Models.User user in userRec.SelectAny(name, userLogon, email))
            {
                listRetorno.Add(new User()
                {
                    Id = user.Id.ToString(),
                    Name = user.Name,
                    UserLogon = user.UserLogon,
                    //Password = user.Password.UTF8ToByte().DecryptStringAES(key),
                    Email = user.Email,
                    Telephone = user.Telephone,
                    Gender = user.Gender,
                    UrlPhoto = user.Photo,
                    Profile = user.Profile,
                    Occupation = new Profession
                    {
                        Id = user.Occupation.Id.ToString(),
                        Description = user.Occupation.Description,
                        Status = user.Occupation.Status,
                        Administrative = user.Occupation.Administrative,
                        CreatedDate = user.Occupation.CreatedDate,
                        ModifiedDate = user.Occupation.ModifiedDate
                    }
                });
            }
            return listRetorno;

        }

        public bool Login(string userLogin, string password)
        {
            using var context = new MongoContext(_configuration);
            using var userRec = new data.UserRepository(context);
            string key = _configuration.GetSection("key").Value;

            return userRec.Login(userLogin, password.EncryptStringEAS(key).ByteToUTF8());
        }

        public string Insert(User record)
        {
            if (record is null) { return string.Empty; }
            var context = new MongoContext(_configuration);
            var userRec = new data.UserRepository(context);

            if (userRec.IsUserExistent(record.UserLogon))
            { throw new UserCustomException("Usuário já existente."); }

            if (userRec.IsEmailExistent(record.Email))
            { throw new UserCustomException("Email já existente."); }

            _ = userRec.Add(FillUserDataModel(record));
            _ = context.SaveChanges();

            IQueryable<data.Models.User> users = userRec.GetAll().Result;
            return DBUtils.ObjectIdToString(users.OrderByDescending(x => x.Id).Select(x => x.Id).First());
        }

        public string Update(string id, User record)
        {
            if (record is null) { return string.Empty; }
            var context = new MongoContext(_configuration);
            var userRec = new data.UserRepository(context);

            userRec.Update(id, FillUserDataModel(record));
            _ = context.SaveChanges();

            return id;
        }

        public bool Delete(string Id)
        {
            using var context = new MongoContext(_configuration);
            using var userRec = new data.UserRepository(context);

            try
            {
                var originalUser = userRec.GetById(Id).Result;
                originalUser.IsDeleted = true;
                originalUser.DeletedDate = DateTime.Now;

                userRec.Update(Id, originalUser);

                _ = context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                new LogErrorService(_configuration).Insert(e);
                return false;
            }
        }

        public data.Models.User FillUserDataModel(User record)
        {
            string key = _configuration.GetSection("key").Value;
            return new data.Models.User
            {
                Name = record.Name,
                UserLogon = record.UserLogon,
                Password = record.Password.EncryptStringEAS(key).ByteToUTF8(),
                Email = record.Email,
                Telephone = record.Telephone,
                Gender = record.Gender,
                Profile = record.Profile,
                Occupation = new data.Models.Profession
                {
                    Id = DBUtils.StringToObjectId(record.Occupation.Id),
                    Description = record.Occupation.Description,
                    Status = record.Occupation.Status
                },
                Photo = record.UrlPhoto,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                DeletedDate = DateTime.MinValue
            };
        }

    }
}
