using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.QueryPatient
{
    public class QueryPatientDtoCreateResult
    {
        public int IdQueryPartient { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int IdStatus { get; set; }
        public int IdDoctor { get; set; }
        public int IdPatient { get; set; }
        public DateTime createAt { get; set; }
    }
}
