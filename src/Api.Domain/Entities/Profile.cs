using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class Profile : BaseEntity
    {
        public int IdProfile { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}