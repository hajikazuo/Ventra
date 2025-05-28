using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Ventra.Domain.Entities.Users
{
    public class User : IdentityUser<Guid>
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
