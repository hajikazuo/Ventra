using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ventra.Domain.Resources.Portuguese;

namespace Ventra.Domain.Entities
{
    public class Product : BaseEntity
    {
        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [MaxLength(100)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [MaxLength(3000)]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Preço")]
        public decimal Price { get; set; }

        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [Display(Name = "Estoque")]
        public int Stock { get; set; }

        public Category? Category { get; set; }

        [Display(Name = "Categoria")]
        public Guid CategoryId { get; set; }

        public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();
    }

}
