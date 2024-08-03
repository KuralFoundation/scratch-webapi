using ScratchWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ScratchWebApi;

public class UserRepository
{
    private readonly string _connectionString;

    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IEnumerable<User> GetAllUsers()
    {
        var users = new List<User>();

        using (var connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand("SELECT Id, Name, Email, Country, City FROM Users", connection);
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Email = (string)reader["Email"],
                        Country = (string)reader["Country"],
                        City = (string)reader["City"]
                    });
                }
            }
        }

        return users;
    }

    public User GetUserById(int id)
    {
        User user = null;

        using (var connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand("SELECT Id, Name, Email, Country, City FROM Users WHERE Id = @Id", connection);
            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    user = new User
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Email = (string)reader["Email"],
                        Country = (string)reader["Country"],
                        City = (string)reader["City"]
                    };
                }
            }
        }

        return user;
    }

    public void AddUser(User user)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand(
                "INSERT INTO Users (Name, Email, Country, City) VALUES (@Name, @Email, @Country, @City)", connection);
            command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar) { Value = user.Name });
            command.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar) { Value = user.Email });
            command.Parameters.Add(new SqlParameter("@Country", SqlDbType.NVarChar) { Value = user.Country });
            command.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar) { Value = user.City });

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public void UpdateUser(User user)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand(
                "UPDATE Users SET Name = @Name, Email = @Email, Country = @Country, City = @City WHERE Id = @Id", connection);
            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = user.Id });
            command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar) { Value = user.Name });
            command.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar) { Value = user.Email });
            command.Parameters.Add(new SqlParameter("@Country", SqlDbType.NVarChar) { Value = user.Country });
            command.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar) { Value = user.City });

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public void DeleteUser(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand("DELETE FROM Users WHERE Id = @Id", connection);
            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
