using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Doctor
{
    public class DoctorDtoCreate
    {
        [Required(ErrorMessage = "Specialty é campo obrigatório")]
        public string Specialty { get; set; }
    }
}
