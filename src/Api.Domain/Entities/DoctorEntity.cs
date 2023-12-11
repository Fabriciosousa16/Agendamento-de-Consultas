using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Api.Domain.Entities
{
    public class DoctorEntity : BaseEntity
    {
        public int IdDoctor { get; set; }
        public string Specialty { get; set; }
        public string WorkSchedule { get; set; }

        [JsonIgnore]
        public UserEntity User { get; set; }
        [JsonIgnore]
        public ICollection<QueryEntity> Queries { get; set; }
    }
}
