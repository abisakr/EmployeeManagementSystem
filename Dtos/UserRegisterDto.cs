using System.ComponentModel.DataAnnotations;

namespace Employee_Management_System.Dtos
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "UserName is required.")]
        [MinLength(3, ErrorMessage = "UserName must be at least 3 characters long.")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }
    }
}
