using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ventra.Domain.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Preço")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Estoque")]
        public int Stock { get; set; }

        [MaxLength(100)]
        [Display(Name = "Imagem")]
        public string? Image { get; set; }

        public Category? Category { get; set; }

        [Display(Name = "Categoria")]
        public Guid CategoryId { get; set; }
    }

}
