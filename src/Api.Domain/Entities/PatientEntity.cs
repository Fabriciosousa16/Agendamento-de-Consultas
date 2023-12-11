using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Api.Domain.Entities
{
    public class PatientEntity : BaseEntity
    {
        public int IdPatient { get; set; }
        public string Flat { get; set; }

        [JsonIgnore]
        public UserEntity User { get; set; }
        [JsonIgnore]
        public ICollection<QueryEntity> Queries { get; set; }
        [JsonIgnore]
        public ICollection<PatientHistoryEntity> PatientHistories { get; set; }
    }
}
