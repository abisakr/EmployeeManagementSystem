using System.ComponentModel.DataAnnotations;

namespace Employee_Management_System.Dtos
{
    public class EmployeeDto
    {
        [Required(ErrorMessage = "EmployeeName is required.")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        public string EmployeeName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Department is required.")]
        public string Department { get; set; } = string.Empty;

        public string? Position { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        public decimal Salary { get; set; }
    }
}
