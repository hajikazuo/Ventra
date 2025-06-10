using System.ComponentModel.DataAnnotations;
using Ventra.Domain.Resources.Portuguese;

namespace Ventra.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [MaxLength(100)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
