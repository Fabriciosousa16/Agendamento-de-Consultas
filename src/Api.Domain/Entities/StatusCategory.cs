using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class StatusCategory : BaseEntity
    {
        public int IdStatus { get; set; }
        public string Status { get; set; }
        public ICollection<Query> Query { get; set; }

    }
}
