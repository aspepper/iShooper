using Ishooper.Infra.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ishooper.Infra.Interfaces
{
    public interface IUserService
    {

        User GetById(string id);

        List<User> SelectAny(string name, string userLogon, string email);

        bool Login(string userLogin, string password);

        string Insert(User record);

        string Update(string id, User record);

        bool Delete(string id);

    }
}
