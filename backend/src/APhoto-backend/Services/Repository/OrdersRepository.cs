
using APhoto.Api.Data;
using APhoto.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace APhoto.Api.Services.Repository;

public class OrdersRepository : IOrdersRepository
{
    private readonly APhotosContext _context;

    public OrdersRepository(APhotosContext context)
    {
        _context = context;
    }
    
    public Task<List<Order>> GetAllOrders()
    {
        return _context.Orders.ToListAsync();
    }

    public void Add(Order order)
    {
        _context.Add(order);
        _context.SaveChanges();
    }

    public void AcceptOrder(Order order)
    {
        order.IsAccepted = true;
    }

    public void DeclineOrder(Order order)
    {
        order.IsDeclined = true;
    }
    public void DeleteOrder(Order order)
    {
        _context.Remove(order);
        _context.SaveChanges();
    }
    public Order GetOrderById(uint orderId)
    {
        return _context.Orders.FirstOrDefault(o => o.Id == orderId);
    }
    public void UpdateOrder(Order order)
    {
        _context.SaveChanges();
    }
}