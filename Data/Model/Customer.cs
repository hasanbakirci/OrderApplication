using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Customer : IEntity
    {
       public Guid Id { get; set; }
       public string Name { get; set; }
       public string Email { get; set; }
       public Address Address { get; set; }
       public int AddressId { get; set; }
       public DateTime CreatedAt { get; set; }
       public DateTime UpdatedAt { get; set; }
    }
}