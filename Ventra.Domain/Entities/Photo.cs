using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventra.Domain.Resources.Portuguese;

namespace Ventra.Domain.Entities
{
    public class Photo : BaseEntity
    {
        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [MaxLength(150)]
        [Display(Name = "Nome da imagem")]
        public string? Name { get; set; }

        public Guid? ProductId { get; set; }

        public virtual Product? Product { get; set; }
    }
}
