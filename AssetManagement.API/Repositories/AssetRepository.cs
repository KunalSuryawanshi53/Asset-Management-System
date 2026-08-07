using AssetManagement.API.Data;
using AssetManagement.API.DTOs;
using AssetManagement.API.Interfaces;
using Microsoft.Data.SqlClient;

namespace AssetManagement.API.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private readonly DbConnectionFactory _dbConnectionFactory;

        public AssetRepository(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public int AddAsset(AddAssetDto dto)
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            string query = "INSERT INTO Assets(AssetCode, AssetName, CategoryId, Brand, SerialNumber, PurchasePrice, Status, IsActive, CreatedDate) VALUES(@AssetCode, @AssetName, @CategoryId, @Brand, @SerialNumber, @PurchasePrice, @Status, 1, GETDATE())";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AssetCode", dto.AssetCode);
            command.Parameters.AddWithValue("@AssetName", dto.AssetName);
            command.Parameters.AddWithValue("@CategoryId", dto.CategoryId);
            command.Parameters.AddWithValue("@Brand", dto.Brand);
            command.Parameters.AddWithValue("@SerialNumber", dto.SerialNumber);
            command.Parameters.AddWithValue("@PurchasePrice", dto.PurchasePrice);
            command.Parameters.AddWithValue("@Status", dto.Status);

            connection.Open();

            return command.ExecuteNonQuery();
        }

        public List<AssetResponseDto> GetAllAssets()
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            string query = "SELECT a.AssetId, a.AssetCode, a.AssetName, a.CategoryId, c.CategoryName, a.Brand, a.SerialNumber, a.PurchasePrice, a.Status FROM Assets a INNER JOIN Categories c ON a.CategoryId = c.CategoryId";

            using SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            List<AssetResponseDto> assets = new();

            while (reader.Read())
            {
                AssetResponseDto asset = new AssetResponseDto
                {
                    AssetId = Convert.ToInt32(reader["AssetId"]),
                    AssetCode = reader["AssetCode"].ToString() ?? "",
                    AssetName = reader["AssetName"].ToString() ?? "",
                    CategoryId = Convert.ToInt32(reader["CategoryId"]),
                    CategoryName = reader["CategoryName"].ToString() ?? "",
                    Brand = reader["Brand"].ToString() ?? "",
                    SerialNumber = reader["SerialNumber"].ToString() ?? "",
                    PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"]),
                    Status = reader["Status"].ToString() ?? ""
                };

                assets.Add(asset);
            }

            return assets;
        }

        public AssetResponseDto? GetAssetById(int id)
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            string query = "SELECT a.AssetId, a.AssetCode, a.AssetName, a.CategoryId, c.CategoryName, a.Brand, a.SerialNumber, a.PurchasePrice, a.Status FROM Assets a INNER JOIN Categories c ON a.CategoryId = c.CategoryId WHERE a.AssetId = @AssetId";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AssetId", id);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new AssetResponseDto
                {
                    AssetId = Convert.ToInt32(reader["AssetId"]),
                    AssetCode = reader["AssetCode"].ToString() ?? "",
                    AssetName = reader["AssetName"].ToString() ?? "",
                    CategoryId = Convert.ToInt32(reader["CategoryId"]),
                    CategoryName = reader["CategoryName"].ToString() ?? "",
                    Brand = reader["Brand"].ToString() ?? "",
                    SerialNumber = reader["SerialNumber"].ToString() ?? "",
                    PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"]),
                    Status = reader["Status"].ToString() ?? ""
                };
            }

            return null;
        }

        public int UpdateAsset(UpdateAssetDto dto)
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            string query = "UPDATE Assets SET AssetCode=@AssetCode, AssetName=@AssetName, CategoryId=@CategoryId, Brand=@Brand, SerialNumber=@SerialNumber, PurchasePrice=@PurchasePrice, Status=@Status WHERE AssetId=@AssetId";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AssetId", dto.AssetId);
            command.Parameters.AddWithValue("@AssetCode", dto.AssetCode);
            command.Parameters.AddWithValue("@AssetName", dto.AssetName);
            command.Parameters.AddWithValue("@CategoryId", dto.CategoryId);
            command.Parameters.AddWithValue("@Brand", dto.Brand);
            command.Parameters.AddWithValue("@SerialNumber", dto.SerialNumber);
            command.Parameters.AddWithValue("@PurchasePrice", dto.PurchasePrice);
            command.Parameters.AddWithValue("@Status", dto.Status);

            connection.Open();

            return command.ExecuteNonQuery();
        }

        public int DeleteAsset(int id)
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            string query = "DELETE FROM Assets WHERE AssetId = @AssetId";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AssetId", id);

            connection.Open();

            return command.ExecuteNonQuery();
        }
    }
}