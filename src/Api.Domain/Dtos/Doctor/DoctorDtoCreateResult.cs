using System;

namespace Api.Domain.Dtos.Doctor
{
    public class DoctorDtoCreateResult
    {
        public int IdDoctor { get; set; }
        public string Specialty { get; set; }
        public DateTime createAt { get; set; }
    }
}
