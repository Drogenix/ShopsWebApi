using System.ComponentModel.DataAnnotations;

namespace ShopsWebApi.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(14, MinimumLength = 5)]
        public string Login { get; set; }

        [Required]
        [StringLength(24, MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}