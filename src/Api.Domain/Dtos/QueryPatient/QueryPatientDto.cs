using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.QueryPatient
{
    public class QueryPatientDto
    {
        [Required(ErrorMessage = "IdQueryPartient é campo obrigatório")]
        public int IdQueryPartient { get; set; }

        [Required(ErrorMessage = "StartTime é campo obrigatório.")]
        [DataType(DataType.DateTime, ErrorMessage = "O campo StartTime deve ser uma data e hora válidas.")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "EndTime é campo obrigatório.")]
        [DataType(DataType.DateTime, ErrorMessage = "O campo EndTime deve ser uma data e hora válidas.")]
        public DateTime EndTime { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndTime <= StartTime)
            {
                yield return new ValidationResult("EndTime deve ser superior a StartTime.");
            }
        }

        [Required(ErrorMessage = "IdStatus é campo obrigatório.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O campo IdStatus só pode conter números.")]
        public int IdStatus { get; set; }

        [Required(ErrorMessage = "IdDoctor é campo obrigatório.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O campo IdDoctor só pode conter números.")]
        public int IdDoctor { get; set; }

        [Required(ErrorMessage = "IdPatient é campo obrigatório.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O campo IdPatient só pode conter números.")]
        public int IdPatient { get; set; }

    }
}
