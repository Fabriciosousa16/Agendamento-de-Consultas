using System;
using System.Text.Json.Serialization;

namespace Api.Domain.Entities
{
    public class QueryPartientEntity : BaseEntity
    {
        public int IdQueryPartient { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int IdStatus { get; set; }
        public int IdDoctor { get; set; }
        public int IdPatient { get; set; }
        [JsonIgnore]
        public StatusCategoryEntity Status { get; set; }
        [JsonIgnore]
        public DoctorEntity Doctor { get; set; }
        [JsonIgnore]
        public PatientEntity Patient { get; set; }

    }
}
