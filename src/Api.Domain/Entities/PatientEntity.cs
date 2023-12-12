using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Api.Domain.Entities
{
    public class PatientEntity : BaseEntity
    {
        public int IdPatient { get; set; }
        public string MedicalPlan { get; set; }
        public int IdUser { get; set; }
        [JsonIgnore]
        public UserEntity User { get; set; }
    }
}
