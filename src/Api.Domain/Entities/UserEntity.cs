using System.Text.Json.Serialization;

namespace Api.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public int IdProfile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public ProfileEntity Profile { get; set; }
    }
}
