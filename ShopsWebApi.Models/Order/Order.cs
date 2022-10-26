
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopsWebApi.Models
{
    public class Order
    {
        public int Id{ get; set; }

        [Required]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual List<OrderProduct> Products { get; set; }

        [Required]
        public OrderStatus Status { get; set; }
    }
}
