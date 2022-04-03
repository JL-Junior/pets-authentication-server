using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Pets.Megastore.Auth.Api.Data.Entities
{
    public class User : BaseEntity
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICollection<Roles> Roles { get; set;}

    }
}