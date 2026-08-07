using AssetManagement.API.Data;
using AssetManagement.API.DTOs;
using AssetManagement.API.Interfaces;
using Microsoft.Data.SqlClient;

namespace AssetManagement.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbConnectionFactory _dbConnectionFactory;

        public CategoryRepository(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public int AddCategory(AddCategoryDto dto)
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            string query = @"INSERT INTO Categories
                            (CategoryName, Description, IsActive, CreatedDate)
                            VALUES
                            (@CategoryName, @Description, 1, GETDATE())";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CategoryName", dto.CategoryName);
            command.Parameters.AddWithValue("@Description", dto.Description);

            connection.Open();

            return command.ExecuteNonQuery();
        }

        public List<CategoryResponseDto> GetAllCategories()
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            string query = @"SELECT CategoryId, CategoryName
                            FROM Categories
                            WHERE IsActive = 1
                            ORDER BY CategoryId";

            using SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            List<CategoryResponseDto> categories = new();

            while (reader.Read())
            {
                categories.Add(new CategoryResponseDto
                {
                    CategoryId = Convert.ToInt32(reader["CategoryId"]),
                    CategoryName = reader["CategoryName"].ToString() ?? ""
                });
            }

            return categories;
        }

        public CategoryResponseDto? GetCategoryById(int id)
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            string query = @"SELECT CategoryId, CategoryName
                             FROM Categories
                             WHERE CategoryId = @CategoryId";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CategoryId", id);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new CategoryResponseDto
                {
                    CategoryId = Convert.ToInt32(reader["CategoryId"]),
                    CategoryName = reader["CategoryName"].ToString() ?? ""
                };
            }

            return null;
        }

        public int UpdateCategory(UpdateCategoryDto dto)
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            string query = @"UPDATE Categories
                             SET CategoryName=@CategoryName,
                                 Description=@Description
                             WHERE CategoryId=@CategoryId";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CategoryId", dto.CategoryId);
            command.Parameters.AddWithValue("@CategoryName", dto.CategoryName);
            command.Parameters.AddWithValue("@Description", dto.Description);

            connection.Open();

            return command.ExecuteNonQuery();
        }

        public int DeleteCategory(int id)
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            string query = @"DELETE FROM Categories
                             WHERE CategoryId=@CategoryId";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CategoryId", id);

            connection.Open();

            return command.ExecuteNonQuery();
        }
    }
}