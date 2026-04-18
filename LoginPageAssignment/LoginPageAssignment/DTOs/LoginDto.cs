using System.ComponentModel.DataAnnotations;

namespace LoginPageAssignment.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string EmpEmail { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string EmpPassword { get; set; }
    }
}
