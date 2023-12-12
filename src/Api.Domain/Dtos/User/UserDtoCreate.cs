using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.User
{
    public class UserDtoCreate
    {
        [Required(ErrorMessage = "Nome é campo obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "CPF é campo obrigatório")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O CPF deve estar no formato ###.###.###-##")]

        public string Cpf { get; set; }

        [Required(ErrorMessage = "IdProfile é campo obrigatório.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O campo IdProfile só pode conter números.")]
        public int IdProfile { get; set; }

        [Required(ErrorMessage = "Email é Campo Obrigatório")]
        [EmailAddress(ErrorMessage = "Email no Formato Inválido")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} Caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password é campo obrigatório")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$",
              ErrorMessage = "A senha deve conter pelo menos uma letra, um número, um caractere especial e ter pelo menos 8 caracteres.")]
        public string Password { get; set; }
    }
}
