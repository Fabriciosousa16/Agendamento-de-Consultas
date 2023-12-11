using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class PatientEntity : BaseEntity
    {
        public int IdPatient { get; set; }
        public string Flat { get; set; }

        public UserEntity User { get; set; }
        public ICollection<QueryEntity> Queries { get; set; }
        public ICollection<PatientHistoryEntity> PatientHistories { get; set; }
    }
}
