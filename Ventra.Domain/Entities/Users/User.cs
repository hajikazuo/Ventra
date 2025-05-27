using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventra.Domain.Entities.Users
{
    public class User : IdentityUser<Guid>
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
    }
}
