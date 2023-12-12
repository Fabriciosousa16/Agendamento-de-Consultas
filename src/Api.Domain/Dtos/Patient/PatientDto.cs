using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Patient
{
    public class PatientDto
    {
        [Required(ErrorMessage = "MedicalPlan é campo obrigatório")]
        public string MedicalPlan { get; set; }
    }
}
