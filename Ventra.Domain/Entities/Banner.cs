using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventra.Domain.Resources.Portuguese;

namespace Ventra.Domain.Entities
{
    public class Banner : BaseEntity
    {
        [Required(ErrorMessageResourceType = typeof(TextosValidacao), ErrorMessageResourceName = nameof(TextosValidacao.Required))]
        [MaxLength(150)]
        [Display(Name = "Nome da imagem")]
        public string? Name { get; set; }

        [Display(Name = "Está ativo?")]
        public bool IsActive { get; set; } = true;
    }
}
