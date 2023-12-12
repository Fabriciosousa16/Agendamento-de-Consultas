using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Patient
{
    public class PatientDtoUpdate
    {
        [Required(ErrorMessage = "IdPatient é campo obrigatório")]
        public int IdPatient { get; set; }

        [Required(ErrorMessage = "MedicalPlan é campo obrigatório")]
        public string MedicalPlan { get; set; }
    }
}
