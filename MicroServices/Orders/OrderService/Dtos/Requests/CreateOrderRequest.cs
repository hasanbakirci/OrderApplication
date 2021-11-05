using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Dtos.Requests
{
    public class CreateOrderRequest
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public int AddressId { get; set; }
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
    }
}