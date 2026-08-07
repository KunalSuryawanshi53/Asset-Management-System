using System.ComponentModel.DataAnnotations;

namespace AssetManagement.MVC.Models
{
    public class AddEmployeeViewModel
    {
        [Required]
        public string EmployeeCode { get; set; } = string.Empty;

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public string Designation { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
    }
}