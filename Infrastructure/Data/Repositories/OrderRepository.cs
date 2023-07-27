using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ShopDbContext _context;

    public OrderRepository(ShopDbContext context)
    {
        _context = context;
    }

    public async Task<PagedList<Order>> GetUserOrders(int userId, int page, int itemsPerPage, CancellationToken cancellationToken = default)
    {
        var count = await _context.Orders.Where(order => order.UserId == userId).CountAsync(cancellationToken);
        
        var items =  await _context.Orders
            .Where(order => order.UserId == userId)
            .OrderByDescending(order => order.Date)
            .Skip(Math.Max(0, itemsPerPage * (page - 1)))
            .Take(itemsPerPage)
            .Include(order => order.PaymentMethod)
            .Include(order => order.OrderProductVariations)
            .ThenInclude(orderProductVariation => orderProductVariation.ProductVariation)
            .ThenInclude(productVariation => productVariation.Product)
            .Include(order => order.OrderProductVariations)
            .ThenInclude(orderProductVariation => orderProductVariation.ProductVariation.Size)
            .ThenInclude(size => size.Unit)
            .Include(order => order.OrderProductVariations)
            .ThenInclude(orderProductVariation => orderProductVariation.ProductVariation.Type)
            .ToListAsync(cancellationToken: cancellationToken);

        return new PagedList<Order>(items, count, page, itemsPerPage);
    }

    public async Task<Order> CreateOrder(Order order, CancellationToken cancellationToken = default)
    {
        var addedOrder = _context.Orders.Add(order);
        await _context.SaveChangesAsync(cancellationToken);

        return addedOrder.Entity;
    }

    public async Task<bool> PaymentMethodIsExist(int paymentId, CancellationToken cancellationToken = default)
    {
        return await _context.PaymentMethods.AnyAsync(method => method.Id == paymentId, cancellationToken);
    }
}