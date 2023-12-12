using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Query
{
    public class QueryDto
    {
        [Required(ErrorMessage = "Reason é campo obrigatório")]
        public string Reason { get; set; }

        [Required(ErrorMessage = "MedicalRecord é campo obrigatório")]
        public string MedicalRecord { get; set; }
    }
}
