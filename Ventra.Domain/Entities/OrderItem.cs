using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ventra.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        [Required]
        [Display(Name = "Produto")]
        public Guid ProductId { get; set; }

        [Required]
        [Display(Name = "Quantidade")]
        public float Quantity { get; set; }

        [Required]
        [Display(Name = "Preço Unitário")]
        public double UnitPrice { get; set; }

        [NotMapped]
        [Display(Name = "Total do Item")]
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
