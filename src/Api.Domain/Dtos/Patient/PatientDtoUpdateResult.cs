using System;

namespace Api.Domain.Dtos.Patient
{
    public class PatientDtoUpdateResult
    {
        public int IdPatient { get; set; }
        public string MedicalPlan { get; set; }
        public DateTime updateAt { get; set; }
    }
}
