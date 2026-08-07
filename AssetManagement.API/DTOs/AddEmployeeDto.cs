using System.ComponentModel.DataAnnotations;

namespace AssetManagement.API.DTOs
{
    public class AddEmployeeDto
    {
        [Required(ErrorMessage = "Employee Code is required")]
        [StringLength(10, ErrorMessage = "Employee Code cannot exceed 10 characters")]
        public string EmployeeCode { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Designation is required")]
        [StringLength(50, ErrorMessage = "Designation cannot exceed 50 characters")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Hire Date is required")]
        public DateTime HireDate { get; set; }
    }
}