using System.ComponentModel.DataAnnotations;
namespace WebApiCoreWithAllFeatures.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; } 
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
