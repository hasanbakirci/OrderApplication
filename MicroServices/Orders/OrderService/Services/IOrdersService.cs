using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Dtos.Requests;
using OrderService.Dtos.Responses;

namespace OrderService.Services
{
    public interface IOrdersService
    {
        Task<IEnumerable<OrderResponse>> Get();
        Task<OrderResponse> Get(Guid id);
        Task<Guid> Create(CreateOrderRequest request);
        Task<bool> Update(UpdateOrderRequest request);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<OrderResponse>> GetByCustomerId(Guid id);
        Task<bool> ChangeStatus(Guid id, string status);
        Task<bool> OrderIsExist(Guid id);
    }
}