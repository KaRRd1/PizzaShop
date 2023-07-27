using Application.Dtos;
using Application.Dtos.Order;

namespace Application.Interfaces.Services;

public interface IOrderService
{
    public Task<CreateOrderResponse> CreateOrder(CreateOrderRequest createOrderRequest, int? userId, CancellationToken cancellationToken = default);
    public Task<PagedListResponse<OrderResponse>> GetUserOrders(int userId, int page, CancellationToken cancellationToken = default);
}