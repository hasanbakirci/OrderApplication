using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.Dtos.Responses
{
    public class CustomerResponse
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AddressResponse { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}