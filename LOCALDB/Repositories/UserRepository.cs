using Data.Entities;
using Data.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository : IUserRepositories

    {

        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C-Projects\LOCALDB\LOCALDB\Data\database.mdf;Integrated Security=True;Connect Timeout=30";
        private readonly SqlConnection _connection;

        public UserRepository() 
        {
            CreateUserTableIfNotExists();
        }

        public void CreateUserTableIfNotExists() 
        { 
            try
            {
                string createUsersTableQuery = @"
                IF OBJECT_ID('Users', 'U') IS NULL

			CREATE TABLE Users(
					Id INT IDENTITY (1,1) PRIMARY KEY,
					FirstName NVARCHAR(50) NOT NULL,
					LastName NVARCHAR(50) NOT NULL,
					Email NVARCHAR(100) NOT NULL,
					PhoneNumbe NVARCHAR(15) NULL
					)
                ";

                using var connection = new SqlConnection(_connectionString);
                connection.Open();

                using var command = new SqlCommand(createUsersTableQuery, connection);
                command.ExecuteNonQuery();
            }
            catch 
            {
                
            }
        }
        public bool Create(UserEntity userEntity)
        {
            try
            {
                string insertQuery = @"
                    INSERT INTO Users (FirstName, LastName, Email, PhoneNumber) 
                    VALUES (@FirstName, @LastName, @Email, @PhoneNumber)
                 ";

                using var connection = new SqlConnection(_connectionString);
                connection.Open();

                using var command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@FirstName", userEntity.FirstName);
                command.Parameters.AddWithValue("@LastName", userEntity.LastName);
                command.Parameters.AddWithValue("@Email", userEntity.Email);
                command.Parameters.AddWithValue("@PhoneNumber", userEntity.PhoneNumber ?? (object)DBNull.Value);


                command.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<UserEntity> GetAll()
        {
            try
            {
                var users = new List<UserEntity>();

                string selectQuery = @"
                    SELECT * FROM Users
                 ";

                using var connection = new SqlConnection(_connectionString);
                connection.Open();

                using var command = new SqlCommand(selectQuery, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new UserEntity
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Email = reader.GetString(3),
                        PhoneNumber = reader.IsDBNull(4) ? null : reader.GetString(4)
                    });
                }

                return users;
            }
            catch
            {
                return null!;

            }
        }
    }
}
