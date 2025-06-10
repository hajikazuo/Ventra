using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ventra.Domain.Enums;
using Ventra.Domain.Resources.Portuguese;

namespace Ventra.Domain.Entities
{
    public class Order : BaseEntity
    {
        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [Display(Name = "Data/Hora do Pedido")]
        public DateTime OrderDateTime { get; set; }

        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [Display(Name = "Valor Total")]
        public double TotalValue { get; set; }

        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [Display(Name = "Status")]
        public OrderStatus Status { get; set; }

        [Display(Name = "Cliente")]
        public Guid? ClientId { get; set; }

        [Display(Name = "ID do Carrinho")]
        public string CartId { get; set; }

        [ForeignKey("ClientId")]
        public Client? Client { get; }

        [Display(Name = "Endereço")]
        public Address? Address { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
