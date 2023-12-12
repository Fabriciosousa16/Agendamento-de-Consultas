using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email é Campo Obrigatório")]
        [EmailAddress(ErrorMessage = "Email no Formato Inválido")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} Caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é Campo Obrigatório")]
        public string Password { get; set; }
    }
}
