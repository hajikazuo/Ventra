using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Ventra.Domain.Resources.Portuguese;

namespace Ventra.Domain.Entities
{
    [Owned]
    public class Address
    {
        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [MaxLength(100)]
        [Display(Name = "Rua")]
        public string Street { get; set; }

        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [MaxLength(10)]
        [Display(Name = "Número")]
        public string Number { get; set; }

        [MaxLength(100)]
        [Display(Name = "Complemento")]
        public string Complement { get; set; }

        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [MaxLength(50)]
        [Display(Name = "Bairro")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [MaxLength(50)]
        [Display(Name = "Cidade")]
        public string City { get; set; }

        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [MaxLength(2)]
        [Display(Name = "Estado")]
        public string State { get; set; }

        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [RegularExpression(@"[0-9]{8}$")]
        [MaxLength(8)]
        [UIHint("_CepTemplate")]
        [Display(Name = "CEP")]
        public string ZipCode { get; set; }

        [MaxLength(100)]
        [Display(Name = "Referência")]
        public string Reference { get; set; }
    }
}
