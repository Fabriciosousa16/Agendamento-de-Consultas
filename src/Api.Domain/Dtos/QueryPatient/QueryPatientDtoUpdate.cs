using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.QueryPatient
{
    public class QueryPatientDtoUpdate
    {
        [Required(ErrorMessage = "IdQueryPartient é campo obrigatório")]
        public int IdQueryPartient { get; set; }

        [Required(ErrorMessage = "IdStatus é campo obrigatório.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O campo IdStatus só pode conter números.")]
        public int IdStatus { get; set; }
    }
}
