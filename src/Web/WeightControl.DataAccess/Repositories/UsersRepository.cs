using System;
using System.Collections.Generic;
using WeightControl.Domain.Entities;

namespace WeightControl.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly List<User> users;
        
        public UsersRepository()
        {
            users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Login = "Gleb",
                    Password = "qwerty"
                },
                new User()
                {
                    Id = 2,
                    Login = "Dzianis",
                    Password = "1234"
                }
            };
        }

        public User GetByLogin(string login)
        {
            foreach (var user in users)
            {
                if (user.Login == login)
                {
                    return user;
                }
            }

            return null;
        }
    }
}