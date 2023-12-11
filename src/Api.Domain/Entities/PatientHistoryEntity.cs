using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class PatientHistoryEntity : BaseEntity
    {
        public int IdHistory { get; set; }
        public int IdPatient { get; set; }
        public int IdQuery { get; set; }

        public PatientEntity Patient { get; set; }
        public QueryEntity Query { get; set; }
    }
}
