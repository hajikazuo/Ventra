using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventra.Domain.Enums
{
    public enum UserStatus
    {
        [Display(Name = "Inativo")]
        Inactive = 0,

        [Display(Name = "Ativo")]
        Active = 1,

        [Display(Name = "Pendente")]
        Pending = 2,

        [Display(Name = "Especial")]
        Special = 3
    }
}
