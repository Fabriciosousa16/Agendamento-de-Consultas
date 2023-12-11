using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class Doctor : BaseEntity
    {
        public int IdDoctor { get; set; }
        public string Specialty { get; set; }
        public string WorkSchedule { get; set; }

        public User User { get; set; }
        public ICollection<Query> Queries { get; set; }
    }
}
