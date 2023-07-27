using Domain.Entities;
using Domain.Utils;

namespace Domain.Interfaces.Repositories;

public interface IOrderRepository
{
    Task<PagedList<Order>> GetUserOrders(int userId, int page, int itemsPerPage ,CancellationToken cancellationToken = default);
    public Task<Order> CreateOrder(Order order, CancellationToken cancellationToken = default);
    public Task<bool> PaymentMethodIsExist(int paymentId, CancellationToken cancellationToken = default);
}