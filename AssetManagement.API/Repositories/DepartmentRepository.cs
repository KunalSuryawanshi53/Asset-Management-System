using AssetManagement.API.Data;
using AssetManagement.API.DTOs;
using AssetManagement.API.Interfaces;
using Microsoft.Data.SqlClient;

namespace AssetManagement.API.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DbConnectionFactory _dbConnectionFactory;

        public DepartmentRepository(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public int AddDepartment(AddDepartmentDto dto)
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            string query = "INSERT INTO Departments(DepartmentName, Description, IsActive, CreatedDate) VALUES(@DepartmentName, @Description, 1, GETDATE())";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DepartmentName", dto.DepartmentName);
            command.Parameters.AddWithValue("@Description", dto.Description);

            connection.Open();

            return command.ExecuteNonQuery();
        }

        public List<DepartmentResponseDto> GetAllDepartments()
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            string query = "SELECT DepartmentId, DepartmentName, Description FROM Departments";

            using SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            List<DepartmentResponseDto> departments = new();

            while (reader.Read())
            {
                DepartmentResponseDto department = new DepartmentResponseDto
                {
                    DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                    DepartmentName = reader["DepartmentName"].ToString() ?? "",
                    Description = reader["Description"]?.ToString() ?? ""
                };

                departments.Add(department);
            }

            return departments;
        }

        public DepartmentResponseDto? GetDepartmentById(int id)
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            string query = "SELECT DepartmentId, DepartmentName, Description FROM Departments WHERE DepartmentId = @DepartmentId";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DepartmentId", id);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new DepartmentResponseDto
                {
                    DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                    DepartmentName = reader["DepartmentName"].ToString() ?? "",
                    Description = reader["Description"]?.ToString() ?? ""
                };
            }

            return null;
        }

        public int UpdateDepartment(UpdateDepartmentDto dto)
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            string query = "UPDATE Departments SET DepartmentName = @DepartmentName, Description = @Description WHERE DepartmentId = @DepartmentId";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DepartmentId", dto.DepartmentId);
            command.Parameters.AddWithValue("@DepartmentName", dto.DepartmentName);
            command.Parameters.AddWithValue("@Description", dto.Description);

            connection.Open();

            return command.ExecuteNonQuery();
        }

        public int DeleteDepartment(int id)
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            string query = "DELETE FROM Departments WHERE DepartmentId = @DepartmentId";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DepartmentId", id);

            connection.Open();

            return command.ExecuteNonQuery();
        }
    }
}