using System.ComponentModel.DataAnnotations;

namespace AssetManagement.MVC.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        [Required]
        public string EmployeeCode { get; set; } = string.Empty;

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; } = string.Empty;

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; } = string.Empty;

        [Required]
        public string Designation { get; set; } = string.Empty;

        [Required]
        public DateTime HireDate { get; set; }
    }
}