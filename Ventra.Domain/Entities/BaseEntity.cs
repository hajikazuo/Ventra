using System.ComponentModel.DataAnnotations;

namespace Ventra.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        [Display(Name = "Data de Criação")]
        public DateTimeOffset DateCreated { get; set; }

        [Display(Name = "Data de Atualização")]
        public DateTimeOffset DateUpdated { get; set; }
    }
}
