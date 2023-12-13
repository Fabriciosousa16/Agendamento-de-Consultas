using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Query
{
    public class QueryDtoUpdate
    {
        [Required(ErrorMessage = "IdQuery é campo obrigatório")]
        public int IdQuery { get; set; }

        [Required(ErrorMessage = "Reason é campo obrigatório")]
        public string Reason { get; set; }

        [Required(ErrorMessage = "MedicalRecord é campo obrigatório")]
        public string MedicalRecord { get; set; }
        [Required(ErrorMessage = "IdDoctor é campo obrigatório")]
        public int IdDoctor { get; set; }
    }
}
