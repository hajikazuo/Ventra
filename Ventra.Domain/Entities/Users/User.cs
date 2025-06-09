using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Ventra.Domain.Entities.Users
{
    public class User : IdentityUser<Guid>
    {
        [Display(Name = "Cliente")]
        public Guid? ClientId { get; set; }
        public virtual Client? Client { get; set; }

    }
}
