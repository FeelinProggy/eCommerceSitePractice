using System.ComponentModel.DataAnnotations;

namespace eCommerceSitePractice.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string? Phone { get; set; }

        public string? Username { get; set; }
    }
}
