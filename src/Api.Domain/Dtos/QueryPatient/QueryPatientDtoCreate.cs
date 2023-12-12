using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.QueryPatient
{
    public class QueryPatientDtoCreate
    {
        [Required(ErrorMessage = "StartTime é campo obrigatório.")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "EndTime é campo obrigatório.")]
        public DateTime EndTime { get; set; }

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
