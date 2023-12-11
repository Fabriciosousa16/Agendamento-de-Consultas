using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Api.Domain.Entities
{
    public class QueryEntity : BaseEntity
    {
        public int IdQuery { get; set; }
        public DateTime ConsultationSchedule { get; set; }
        public int Status { get; set; } // Chave estrangeira referenciando TypeCategory.IdTypeCategory
        public string Reason { get; set; }
        public string MedicalRecord { get; set; }
        public int IdDoctor { get; set; }
        public int IdPatient { get; set; }

        [JsonIgnore]
        public DoctorEntity Doctor { get; set; }
        [JsonIgnore]
        public PatientEntity Patient { get; set; }
        [JsonIgnore]
        public ProfileEntity StatusCategory { get; set; }
        [JsonIgnore]
        public ICollection<PatientHistoryEntity> PatientHistories { get; set; }
    }
}
