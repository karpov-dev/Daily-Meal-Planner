using Business_Layer;
using Data_Access_Layer.DAOInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.DAOClasses
{
    public class UserDAO : IUserDAO
    {
        DataBase _database = DataBase.GetInstance();

        public User GetUser()
        {
            return _database.User;
        }
    }
}
