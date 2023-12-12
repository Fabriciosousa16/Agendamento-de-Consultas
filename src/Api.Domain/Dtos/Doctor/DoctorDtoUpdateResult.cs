using System;

namespace Api.Domain.Dtos.Doctor
{
    public class DoctorDtoUpdateResult
    {
        public int IdDoctor { get; set; }
        public string Specialty { get; set; }
        public DateTime updateAt { get; set; }
    }
}
