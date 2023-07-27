using Application.Dtos;
using Application.Dtos.Order;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<CreateOrderResponse> CreateOrder(CreateOrderRequest createOrderRequest, int? userId, CancellationToken cancellationToken = default)
    {
        var order = _mapper.Map<Order>(createOrderRequest);
        order.UserId = userId;
        order.StatusId = 1;

        var createdOrder = await _orderRepository.CreateOrder(order, cancellationToken);

        return new CreateOrderResponse { OrderId = createdOrder.Id };
    }
    
    public async Task<PagedListResponse<OrderResponse>> GetUserOrders(int userId, int page, CancellationToken cancellationToken = default)
    {
        var userOrders = await _orderRepository.GetUserOrders(userId, page, 4, cancellationToken);
        var ordersResponse = _mapper.Map<PagedListResponse<OrderResponse>>(userOrders);

        return ordersResponse;
    }
}