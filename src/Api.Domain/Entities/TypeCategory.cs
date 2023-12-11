using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class TypeCategory : BaseEntity
    {
        public int IdTypeCategory { get; set; }
        public int IdCategory { get; set; }
        public string Name { get; set; }

        public Category Category { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
