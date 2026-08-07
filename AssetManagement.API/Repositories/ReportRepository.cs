using AssetManagement.API.Data;
using AssetManagement.API.DTOs;
using AssetManagement.API.Interfaces;
using Microsoft.Data.SqlClient;

namespace AssetManagement.API.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly DbConnectionFactory _dbConnectionFactory;

        public ReportRepository(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public DashboardReportDto GetDashboardReport()
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection();

            connection.Open();

            DashboardReportDto report = new();

            
            using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Assets", connection))
            {
                report.TotalAssets = Convert.ToInt32(command.ExecuteScalar());
            }

          
            using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Assets WHERE Status='Available'", connection))
            {
                report.AvailableAssets = Convert.ToInt32(command.ExecuteScalar());
            }

            
            using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Assets WHERE Status='Assigned'", connection))
            {
                report.AssignedAssets = Convert.ToInt32(command.ExecuteScalar());
            }

            
            using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM AssetAssignments WHERE ReturnedDate IS NOT NULL", connection))
            {
                report.ReturnedAssets = Convert.ToInt32(command.ExecuteScalar());
            }

            return report;
        }
    }
}