using System.ComponentModel.DataAnnotations;

namespace Mercadoria_Apresentation.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid format email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
