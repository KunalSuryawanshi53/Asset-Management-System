using AssetManagement.API.Data;
using AssetManagement.API.DTOs;
using AssetManagement.API.Interfaces;
using Microsoft.Data.SqlClient;

namespace AssetManagement.API.Repositories
{
    public class AssetAssignmentRepository : IAssetAssignmentRepository
    {
        private readonly DbConnectionFactory _dbConnectionFactory;

        public AssetAssignmentRepository(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public int AssignAsset(AddAssetAssignmentDto dto)
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            connection.Open();

            using SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                // Step 1 : Check Asset Status

                string checkQuery = "SELECT Status FROM Assets WHERE AssetId=@AssetId";

                using SqlCommand checkCommand = new SqlCommand(checkQuery, connection, transaction);

                checkCommand.Parameters.AddWithValue("@AssetId", dto.AssetId);

                string status = checkCommand.ExecuteScalar()?.ToString() ?? "";

                if (status == "Assigned")
                {
                    transaction.Rollback();
                    return 0;
                }

                // Step 2 : Insert Assignment

                string insertQuery = "INSERT INTO AssetAssignments(EmployeeId, AssetId, AssignedDate, Remarks) VALUES(@EmployeeId,@AssetId,GETDATE(),@Remarks)";

                using SqlCommand insertCommand = new SqlCommand(insertQuery, connection, transaction);

                insertCommand.Parameters.AddWithValue("@EmployeeId", dto.EmployeeId);
                insertCommand.Parameters.AddWithValue("@AssetId", dto.AssetId);
                insertCommand.Parameters.AddWithValue("@Remarks", dto.Remarks);

                insertCommand.ExecuteNonQuery();

                // Step 3 : Update Asset Status

                string updateQuery = "UPDATE Assets SET Status='Assigned' WHERE AssetId=@AssetId";

                using SqlCommand updateCommand = new SqlCommand(updateQuery, connection, transaction);

                updateCommand.Parameters.AddWithValue("@AssetId", dto.AssetId);

                updateCommand.ExecuteNonQuery();

                // Step 4 : Commit

                transaction.Commit();

                return 1;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public List<AssetAssignmentResponseDto> GetAllAssignments()
        {
            List<AssetAssignmentResponseDto> assignments = new();

            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            string query = "SELECT aa.AssignmentId, CONCAT(e.FirstName,' ',e.LastName) AS EmployeeName, a.AssetName, aa.AssignedDate, aa.ReturnedDate, aa.Remarks FROM AssetAssignments aa INNER JOIN Employees e ON aa.EmployeeId = e.EmployeeId INNER JOIN Assets a ON aa.AssetId = a.AssetId";

            using SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                assignments.Add(new AssetAssignmentResponseDto
                {
                    AssignmentId = Convert.ToInt32(reader["AssignmentId"]),
                    EmployeeName = reader["EmployeeName"]?.ToString() ?? "",
                    AssetName = reader["AssetName"]?.ToString() ?? "",
                    AssignedDate = Convert.ToDateTime(reader["AssignedDate"]),
                    ReturnedDate = reader["ReturnedDate"] == DBNull.Value
                                        ? null
                                        : Convert.ToDateTime(reader["ReturnedDate"]),
                    Remarks = reader["Remarks"]?.ToString() ?? ""
                });
            }

            return assignments;
        }

        public int ReturnAsset(ReturnAssetDto dto)
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            connection.Open();

            string getAssetQuery = "SELECT AssetId FROM AssetAssignments WHERE AssignmentId=@AssignmentId";

            using SqlCommand getCommand = new SqlCommand(getAssetQuery, connection);

            getCommand.Parameters.AddWithValue("@AssignmentId", dto.AssignmentId);

            int assetId = Convert.ToInt32(getCommand.ExecuteScalar());

            string returnQuery = "UPDATE AssetAssignments SET ReturnedDate=@ReturnedDate WHERE AssignmentId=@AssignmentId AND ReturnedDate IS NULL";

            using SqlCommand returnCommand = new SqlCommand(returnQuery, connection);

            returnCommand.Parameters.AddWithValue("@ReturnedDate", dto.ReturnedDate);
            returnCommand.Parameters.AddWithValue("@AssignmentId", dto.AssignmentId);

            int result = returnCommand.ExecuteNonQuery();

            // Update Asset Status only if return succeeded
            if (result > 0)
            {
                string updateAssetQuery = "UPDATE Assets SET Status='Available' WHERE AssetId=@AssetId";

                using SqlCommand updateCommand = new SqlCommand(updateAssetQuery, connection);

                updateCommand.Parameters.AddWithValue("@AssetId", assetId);

                updateCommand.ExecuteNonQuery();
            }

            return result;
        }
    }
}