using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ventra.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public float Quantity { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        [NotMapped]
        public double ItemTotal
        {
            get
            {
                return Quantity * UnitPrice;
            }
        }

        [ForeignKey("OrderId")]
        public Order? Order { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}
