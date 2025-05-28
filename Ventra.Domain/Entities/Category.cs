using System.ComponentModel.DataAnnotations;

namespace Ventra.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
