using System.Text.Json.Serialization;

namespace Api.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public int Profile { get; set; } // Chave estrangeira referenciando TypeCategory.IdTypeCategory
        public string Email { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public ProfileEntity ProfileStatus { get; set; }
        [JsonIgnore]
        public DoctorEntity Doctor { get; set; }
        [JsonIgnore]
        public PatientEntity Patient { get; set; }
    }
}
