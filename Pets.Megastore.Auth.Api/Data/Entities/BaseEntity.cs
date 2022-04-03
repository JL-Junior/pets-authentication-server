using System;
using System.Collections.Generic;

namespace Pets.Megastore.Auth.Api.Data.Entities
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}