using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.User
{
    public class UserDtoCreateResult
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int IdProfile { get; set; }

        public DateTime createAt { get; set; }
    }
}
