using System.ComponentModel.DataAnnotations;

namespace epistle_app.Models
{
    public class _LoginModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please provide a valid Username")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters.")]
        public string? Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please provide a valid password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
