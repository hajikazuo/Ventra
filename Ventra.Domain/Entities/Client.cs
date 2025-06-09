using System.ComponentModel.DataAnnotations;
using Ventra.Domain.Entities.Users;
using Ventra.Domain.Enums;

namespace Ventra.Domain.Entities
{
    public class Client : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DateBirth { get; set; }

        [Required]
        [MaxLength(11)]
        [RegularExpression(@"[0-9]{11}$")]
        public string CPF { get; set; }

        [Required]
        [MaxLength(11)]
        [RegularExpression(@"[0-9]{11}$")]
        public string Telephone { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        public UserStatus Status { get; set; }

        public Address? Address { get; set; }

        public virtual User? User { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
