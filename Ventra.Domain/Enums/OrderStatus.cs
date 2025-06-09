using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventra.Domain.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "Carrinho")]
        Cart,

        [Display(Name = "Pedido Realizado")]
        Placed,

        [Display(Name = "Verificado")]
        Verified,

        [Display(Name = "Atendido")]
        Fulfilled,

        [Display(Name = "Entregue")]
        Delivered,

        [Display(Name = "Cancelado")]
        Canceled
    }
}
