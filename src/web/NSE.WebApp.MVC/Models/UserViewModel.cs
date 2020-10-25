﻿using NSE.WebApp.MVC;
using System.ComponentModel.DataAnnotations;

namespace NSE.WebApp.MVC.Models
{
    public class UserRegister
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        [Display(Name = "Password", ResourceType = typeof(AuthenticationResources))]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas não conferem.")]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(AuthenticationResources))]
        public string ConfirmPassword { get; set; }
    }

    public class UserLogin
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        [Display(Name = "Password", ResourceType = typeof(AuthenticationResources))]
        public string Password { get; set; }
    }
}