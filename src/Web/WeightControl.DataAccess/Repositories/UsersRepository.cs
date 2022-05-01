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
                        var user = new User
                        {
                            Id = (int)reader?.GetValue(0),
                            Login = (string) reader.GetValue(1),
                            Password = (string) reader.GetValue(2),
                            Email = (string) reader.GetValue(3)
                        };
                        reader.Close();
                        return user;
                    }
                }
                
                reader.Close();
            }
            
            return null;
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