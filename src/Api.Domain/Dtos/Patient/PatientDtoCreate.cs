using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Patient
{
    public class PatientDtoCreate
    {
        [Required(ErrorMessage = "MedicalPlan é campo obrigatório")]
        public string MedicalPlan { get; set; }

        [Required(ErrorMessage = "IdUser é campo obrigatório")]
        public int IdUser { get; set; }
    }
}
