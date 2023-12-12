
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.User
{
    public class UserDto
    {
        [Required(ErrorMessage = "IdUser é campo obrigatório")]
        public int IdUser { get; set; }
        [Required(ErrorMessage = "Nome é campo obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "CPF é campo obrigatório")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "IdProfile é campo obrigatório.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O campo IdProfile só pode conter números.")]
        public int IdProfile { get; set; }

        [Required(ErrorMessage = "Email é Campo Obrigatório")]
        [EmailAddress(ErrorMessage = "Email no Formato Inválido")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} Caracteres")]
        public string Email { get; set; }
    }
}
