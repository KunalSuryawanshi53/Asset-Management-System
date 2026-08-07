using AssetManagement.API.Data;
using AssetManagement.API.DTOs;
using AssetManagement.API.Interfaces;
using AssetManagement.API.Models;
using Microsoft.Data.SqlClient;

namespace AssetManagement.API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DbConnectionFactory _dbConnectionFactory;

        public EmployeeRepository(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public int AddEmployee(AddEmployeeDto dto)
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            string query = "INSERT INTO Employees(EmployeeCode, FirstName, LastName, Email, Phone, DepartmentId, Designation, HireDate, IsActive, CreatedDate) VALUES(@EmployeeCode, @FirstName, @LastName, @Email, @Phone, @DepartmentId, @Designation, @HireDate, 1, GETDATE())";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EmployeeCode", dto.EmployeeCode);
            command.Parameters.AddWithValue("@FirstName", dto.FirstName);
            command.Parameters.AddWithValue("@LastName", dto.LastName);
            command.Parameters.AddWithValue("@Email", dto.Email);
            command.Parameters.AddWithValue("@Phone", dto.Phone);
            command.Parameters.AddWithValue("@DepartmentId", dto.DepartmentId);
            command.Parameters.AddWithValue("@Designation", dto.Designation);
            command.Parameters.AddWithValue("@HireDate", dto.HireDate);

            connection.Open();

            return command.ExecuteNonQuery();
        }

        public List<EmployeeResponseDto> GetAllEmployees()
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            string query = "SELECT e.EmployeeId, e.EmployeeCode, e.FirstName, e.LastName, e.Email, e.Phone, e.DepartmentId, e.Designation, e.HireDate, d.DepartmentName FROM Employees e INNER JOIN Departments d ON e.DepartmentId = d.DepartmentId";

            using SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            List<EmployeeResponseDto> employees = new();

            while (reader.Read())
            {
                EmployeeResponseDto employee = new EmployeeResponseDto
                {
                    EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                    EmployeeCode = reader["EmployeeCode"].ToString() ?? "",
                    FirstName = reader["FirstName"].ToString() ?? "",
                    LastName = reader["LastName"].ToString() ?? "",
                    Email = reader["Email"].ToString() ?? "",
                    Phone = reader["Phone"].ToString() ?? "",

                    DepartmentId = Convert.ToInt32(reader["DepartmentId"]),

                    DepartmentName = reader["DepartmentName"].ToString() ?? "",

                    Designation = reader["Designation"].ToString() ?? "",

                    HireDate = Convert.ToDateTime(reader["HireDate"])
                };

                employees.Add(employee);
            }

            return employees;
        }

        public EmployeeResponseDto? GetEmployeeById(int id)
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            string query = "SELECT e.EmployeeId, e.EmployeeCode, e.FirstName, e.LastName, e.Email, e.Phone, e.DepartmentId, e.Designation, e.HireDate, d.DepartmentName FROM Employees e INNER JOIN Departments d ON e.DepartmentId = d.DepartmentId WHERE e.EmployeeId = @EmployeeId";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EmployeeId", id);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new EmployeeResponseDto
                {
                    EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                    EmployeeCode = reader["EmployeeCode"].ToString() ?? "",
                    FirstName = reader["FirstName"].ToString() ?? "",
                    LastName = reader["LastName"].ToString() ?? "",
                    Email = reader["Email"].ToString() ?? "",
                    Phone = reader["Phone"].ToString() ?? "",

                    DepartmentId = Convert.ToInt32(reader["DepartmentId"]),

                    DepartmentName = reader["DepartmentName"].ToString() ?? "",

                    Designation = reader["Designation"].ToString() ?? "",

                    HireDate = Convert.ToDateTime(reader["HireDate"])
                };
            }

            return null;
        }

        public List<EmployeeResponseDto> SearchEmployees(string keyword)
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            string query = "SELECT e.EmployeeId, e.EmployeeCode, e.FirstName, e.LastName, e.Email, e.Phone, e.DepartmentId, e.Designation, e.HireDate, d.DepartmentName FROM Employees e INNER JOIN Departments d ON e.DepartmentId = d.DepartmentId WHERE e.EmployeeCode LIKE @Keyword OR e.FirstName LIKE @Keyword OR e.LastName LIKE @Keyword OR e.Email LIKE @Keyword";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            List<EmployeeResponseDto> employees = new();

            while (reader.Read())
            {
                EmployeeResponseDto employee = new EmployeeResponseDto
                {
                    EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                    EmployeeCode = reader["EmployeeCode"].ToString() ?? "",
                    FirstName = reader["FirstName"].ToString() ?? "",
                    LastName = reader["LastName"].ToString() ?? "",
                    Email = reader["Email"].ToString() ?? "",
                    Phone = reader["Phone"].ToString() ?? "",

                    DepartmentId = Convert.ToInt32(reader["DepartmentId"]),

                    DepartmentName = reader["DepartmentName"].ToString() ?? "",

                    Designation = reader["Designation"].ToString() ?? "",

                    HireDate = Convert.ToDateTime(reader["HireDate"])
                };

                employees.Add(employee);
            }

            return employees;
        }

        public int UpdateEmployee(UpdateEmployeeDto dto)
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            string query = "UPDATE Employees SET EmployeeCode=@EmployeeCode, FirstName=@FirstName, LastName=@LastName, Email=@Email, Phone=@Phone, DepartmentId=@DepartmentId, Designation=@Designation, HireDate=@HireDate WHERE EmployeeId=@EmployeeId";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EmployeeId", dto.EmployeeId);
            command.Parameters.AddWithValue("@EmployeeCode", dto.EmployeeCode);
            command.Parameters.AddWithValue("@FirstName", dto.FirstName);
            command.Parameters.AddWithValue("@LastName", dto.LastName);
            command.Parameters.AddWithValue("@Email", dto.Email);
            command.Parameters.AddWithValue("@Phone", dto.Phone);
            command.Parameters.AddWithValue("@DepartmentId", dto.DepartmentId);
            command.Parameters.AddWithValue("@Designation", dto.Designation);
            command.Parameters.AddWithValue("@HireDate", dto.HireDate);

            connection.Open();

            return command.ExecuteNonQuery();
        }

        public int DeleteEmployee(int id)
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            string query = "DELETE FROM Employees WHERE EmployeeId = @EmployeeId";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EmployeeId", id);

            connection.Open();

            return command.ExecuteNonQuery();
        }

        public PagedResult<EmployeeResponseDto> GetEmployeesWithPagination(int pageNumber, int pageSize)
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            connection.Open();

            string countQuery = "SELECT COUNT(*) FROM Employees";

            using SqlCommand countCommand = new SqlCommand(countQuery, connection);

            int totalRecords = Convert.ToInt32(countCommand.ExecuteScalar());

            string query = "SELECT e.EmployeeId, e.EmployeeCode, e.FirstName, e.LastName, e.Email, e.Phone, e.DepartmentId, e.Designation, e.HireDate, d.DepartmentName FROM Employees e INNER JOIN Departments d ON e.DepartmentId = d.DepartmentId ORDER BY e.EmployeeId OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Offset", (pageNumber - 1) * pageSize);
            command.Parameters.AddWithValue("@PageSize", pageSize);

            using SqlDataReader reader = command.ExecuteReader();

            List<EmployeeResponseDto> employees = new();

            while (reader.Read())
            {
                employees.Add(new EmployeeResponseDto
                {
                    EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                    EmployeeCode = reader["EmployeeCode"]?.ToString() ?? "",
                    FirstName = reader["FirstName"]?.ToString() ?? "",
                    LastName = reader["LastName"]?.ToString() ?? "",
                    Email = reader["Email"]?.ToString() ?? "",
                    Phone = reader["Phone"]?.ToString() ?? "",
                    DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                    DepartmentName = reader["DepartmentName"]?.ToString() ?? "",
                    Designation = reader["Designation"]?.ToString() ?? "",
                    HireDate = Convert.ToDateTime(reader["HireDate"])
                });
            }

            return new PagedResult<EmployeeResponseDto>
            {
                Data = employees,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}