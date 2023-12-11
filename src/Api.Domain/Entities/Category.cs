using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class Category : BaseEntity
    {
        public int IdCategory { get; set; }
        public string Type { get; set; }

        public ICollection<TypeCategory> TypeCategories { get; set; }
    }
}
