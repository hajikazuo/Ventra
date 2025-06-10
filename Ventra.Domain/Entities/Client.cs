using System.ComponentModel.DataAnnotations;
using Ventra.Domain.Entities.Users;
using Ventra.Domain.Enums;
using Ventra.Domain.Resources.Portuguese;

namespace Ventra.Domain.Entities
{
    public class Client : BaseEntity
    {
        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [MaxLength(100)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [Display(Name = "Data de Nascimento")]
        public DateTime DateBirth { get; set; }

        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [MaxLength(11)]
        [RegularExpression(@"[0-9]{11}$")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [MaxLength(11)]
        [RegularExpression(@"[0-9]{11}$")]
        [Display(Name = "Telefone")]
        public string Telephone { get; set; }

        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [EmailAddress]
        [MaxLength(50)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [Display(Name = "Status")]
        public UserStatus Status { get; set; }

        [Display(Name = "Endereço")]
        public Address? Address { get; set; }

        public virtual User? User { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
