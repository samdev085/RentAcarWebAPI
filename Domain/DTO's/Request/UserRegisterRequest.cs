﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.Request
{
    public class UserRegisterRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "As senhas devem ser iguais")]
        public string ConfirmPassword { get; set; }

        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
