using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class DoctorEntity : BaseEntity
    {
        public int IdDoctor { get; set; }
        public string Specialty { get; set; }
        public string WorkSchedule { get; set; }

        public UserEntity User { get; set; }
        public ICollection<QueryEntity> Queries { get; set; }
    }
}
