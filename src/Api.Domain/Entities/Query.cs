using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class Query : BaseEntity
    {
        public int IdQuery { get; set; }
        public DateTime ConsultationSchedule { get; set; }
        public int Status { get; set; } // Chave estrangeira referenciando TypeCategory.IdTypeCategory
        public string Reason { get; set; }
        public string MedicalRecord { get; set; }
        public int IdDoctor { get; set; }
        public int IdPatient { get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public Profile StatusCategory { get; set; }
        public ICollection<PatientHistory> PatientHistories { get; set; }
    }
}
