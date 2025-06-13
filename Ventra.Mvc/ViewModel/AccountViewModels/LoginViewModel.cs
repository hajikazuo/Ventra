﻿using System.ComponentModel.DataAnnotations;

namespace Ventra.Mvc.ViewModel.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Lembrar-me?")]
        public bool RememberMe { get; set; }
    }
}
