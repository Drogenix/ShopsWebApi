using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ShopsWebApi.Models
{
    public class Product
    {
        public int Id { get; set; }

        [BindRequired]
        [Required]
        public int ShopId { get; set; }

        [BindRequired]
        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Name { get; set; }

        [BindRequired]
        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Color { get; set; }

        [BindRequired]
        [Required]
        public double Price { get; set; }

        public bool isArchived { get; set; }
    }
}
