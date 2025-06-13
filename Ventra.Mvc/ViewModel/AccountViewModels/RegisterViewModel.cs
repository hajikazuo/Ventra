using System.ComponentModel.DataAnnotations;
using Ventra.Domain.Entities.Users;

namespace Ventra.Mvc.ViewModel.AccountViewModels
{
    public class RegisterViewModel : User
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação devem ser iguais.")]
        public string ConfirmPassword { get; set; }
    }
}
