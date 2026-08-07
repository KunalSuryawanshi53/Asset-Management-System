using AssetManagement.API.Data;
using AssetManagementSystem.DTOs;
using AssetManagementSystem.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace AssetManagementSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbConnectionFactory _dbConnectionFactory;

        public UserRepository(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public LoginResponseDto Login(LoginDto dto)
        {
            // Stopwatch Start
            Stopwatch sw = Stopwatch.StartNew();

            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            connection.Open();

            sw.Stop();
            Console.WriteLine($"Connection Open Time = {sw.ElapsedMilliseconds} ms");

            string query = @"SELECT u.UserId,
                                    u.Username,
                                    r.RoleName
                             FROM Users u
                             INNER JOIN Roles r
                                ON u.RoleId = r.RoleId
                             WHERE u.Username = @Username
                               AND u.Password = @Password
                               AND u.IsActive = 1";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", dto.Username);
            command.Parameters.AddWithValue("@Password", dto.Password);

            // Query Time Start
            sw.Restart();

            using SqlDataReader reader = command.ExecuteReader();

            sw.Stop();
            Console.WriteLine($"ExecuteReader Time = {sw.ElapsedMilliseconds} ms");

            if (reader.Read())
            {
                return new LoginResponseDto
                {
                    UserId = Convert.ToInt32(reader["UserId"]),
                    Username = reader["Username"]?.ToString() ?? "",
                    Role = reader["RoleName"]?.ToString() ?? "",
                    Token = ""
                };
            }

            return null;
        }
    }
}