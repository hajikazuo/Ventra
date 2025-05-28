using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ventra.Domain.Enums;

namespace Ventra.Domain.Entities
{
    public class Order : BaseEntity
    {
        [Required]
        [Display(Name = "Date/Time")]
        public DateTime OrderDateTime { get; set; }

        [Required]
        public double TotalValue { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        public Guid? ClientId { get; set; }

        public string CartId { get; set; }

        [ForeignKey("ClientId")]
        public Client? Client { get; }

        public Address? Address { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
