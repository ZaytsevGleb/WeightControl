using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WeightControl.Domain.Entities;

namespace WeightControl.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly string connectionString = @"Data Source=localhost,1433;Initial Catalog=WeightControlDB;User Id=sa; Password=WeightControl2022;";
        public User GetByLogin(string login)
        {
            User user = null;
            string sqlExpression = $"SELECT Id, Login, Password, Email FROM Users WHERE Login = '{login}'";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                var command = new SqlCommand(sqlExpression,connection);
                var reader = command.ExecuteReader();
                
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        user = new User
                        {
                            Id = reader.GetInt32(0),
                            Login =  reader.GetString(1),
                            Password = reader.GetString(2),
                            Email =  reader.GetString(3)
                        };
                    }
                }
            }
            
            return user;
        }

        
        public User Create(User user)
        {
            string sqlExpression =
                $"INSERT INTO Users (Login, Password, Email) VALUES ('{user.Login}', '{user.Password}', '{user.Email}')";

            using(var connection = new SqlConnection(connectionString))
            {
               connection.Open();
               var command = new SqlCommand(sqlExpression, connection);
               command.ExecuteNonQuery();
            }

            return user;
        }
    }
}