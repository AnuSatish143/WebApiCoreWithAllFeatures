using System.ComponentModel.DataAnnotations;
namespace WebApiCoreWithAllFeatures.DTOs
{
    public class RegisterDto
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
