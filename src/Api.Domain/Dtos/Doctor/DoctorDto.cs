using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.Doctor
{
    public class DoctorDto
    {
        [Required(ErrorMessage = "IdDoctor é campo obrigatório")]
        public int IdDoctor { get; set; }

        [Required(ErrorMessage = "Specialty é campo obrigatório")]
        public string Specialty { get; set; }

        [Required(ErrorMessage = "IdUser é campo obrigatório")]
        public int IdUser { get; set; }
    }
}
