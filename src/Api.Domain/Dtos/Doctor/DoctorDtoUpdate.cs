using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Doctor
{
    public class DoctorDtoUpdate
    {
        [Required(ErrorMessage = "IdDoctor é campo obrigatório")]
        public int IdDoctor { get; set; }

        [Required(ErrorMessage = "Specialty é campo obrigatório")]
        public string Specialty { get; set; }

    }
}
