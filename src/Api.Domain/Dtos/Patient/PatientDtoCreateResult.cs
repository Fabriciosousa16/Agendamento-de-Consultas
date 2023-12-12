using System;

namespace Api.Domain.Dtos.Patient
{
    public class PatientDtoCreateResult
    {
        public int IdPatient { get; set; }
        public string MedicalPlan { get; set; }
        public DateTime createAt { get; set; }
    }
}
