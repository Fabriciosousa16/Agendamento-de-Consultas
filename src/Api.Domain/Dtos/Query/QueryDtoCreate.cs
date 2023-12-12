using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.Query
{
    public class QueryDtoCreate
    {
        [Required(ErrorMessage = "Reason é campo obrigatório")]
        public string Reason { get; set; }

        [Required(ErrorMessage = "MedicalRecord é campo obrigatório")]
        public string MedicalRecord { get; set; }
    }
}
