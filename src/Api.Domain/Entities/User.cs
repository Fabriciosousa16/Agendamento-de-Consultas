using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class User : BaseEntity
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public int Profile { get; set; } // Chave estrangeira referenciando TypeCategory.IdTypeCategory
        public string Email { get; set; }
        public string Password { get; set; }

        public Profile ProfileStatus { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
