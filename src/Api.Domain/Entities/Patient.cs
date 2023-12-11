using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class Patient : BaseEntity
    {
        public int IdPatient { get; set; }
        public string Flat { get; set; }

        public User User { get; set; }
        public ICollection<Query> Queries { get; set; }
        public ICollection<PatientHistory> PatientHistories { get; set; }
    }
}
