using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Dtos.Requests
{
    public class CreateOrderRequest
    {
        [Required(ErrorMessage = "Customer Id is required")]
        public Guid CustomerId { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Address Id is required")]
        public int AddressId { get; set; }
        [Required(ErrorMessage = "Product Id is required")]
        public Guid ProductId { get; set; }
    }
}