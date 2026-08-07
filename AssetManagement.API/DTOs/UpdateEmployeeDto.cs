namespace AssetManagement.API.DTOs
{
    public class UpdateEmployeeDto
    {
        public int EmployeeId { get; set; }

        public string EmployeeCode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int DepartmentId { get; set; }

        public string Designation { get; set; }

        public DateTime HireDate { get; set; }
    }
}