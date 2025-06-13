using System.ComponentModel.DataAnnotations;

namespace Ventra.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        [Display(Name = "Data de Cadastro")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset DateCreated { get; set; }

        [Display(Name = "Data de Atualização")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset DateUpdated { get; set; }
    }
}
