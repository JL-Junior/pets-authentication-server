using System.Collections.Generic;

namespace Pets.Megastore.Auth.Api.Data.Entities
{
    public class Roles
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }

    }
}