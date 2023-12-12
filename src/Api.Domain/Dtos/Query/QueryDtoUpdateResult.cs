using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.Query
{
    public class QueryDtoUpdateResult
    {
        public int IdQuery { get; set; }
        public string Reason { get; set; }
        public string MedicalRecord { get; set; }
        public int IdDoctor { get; set; }
        public int IdPatient { get; set; }
        public DateTime createAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
