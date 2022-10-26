using System.ComponentModel.DataAnnotations;

namespace ShopsWebApi.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Name { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6)]
        public string City { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 6)]
        public string Street { get; set; }
        [Required]
        public int HomeNum { get; set; }
    }
}
