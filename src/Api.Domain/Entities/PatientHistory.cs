using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class PatientHistory : BaseEntity
    {
        public int IdHistory { get; set; }
        public int IdPatient { get; set; }
        public int IdQuery { get; set; }

        public Patient Patient { get; set; }
        public Query Query { get; set; }
    }
}
