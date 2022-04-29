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
            User user = new User();
            string sqlExpression = $"SELECT Id, Login, Password, Email FROM Users WHERE Login = '{login}'";
            
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(); 
                command.Connection = connection;
                command.CommandText = sqlExpression;
                var reader = command.ExecuteReader();
                
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        user.Id = (int)reader.GetValue(0);
                        user.Login = (string) reader.GetValue(1);
                        user.Password = (string) reader.GetValue(2);
                        user.Email = (string) reader.GetValue(3);   
                    }
                }
                reader.Close();
            }

            return user;

        }

        
        public User Create(User user)
        {
            string sqlExpression =
                $"INSERT INTO Users (Login, Password, Email) VALUES {user.Login}, {user.Password}, {user.Email}";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = sqlExpression;
            }

            return user;
        }
    }
}