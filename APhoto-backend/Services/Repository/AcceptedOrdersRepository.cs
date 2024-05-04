using APhoto_backend.Data;
using APhoto_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace APhoto_backend.Services.Repository;

public class AcceptedOrdersRepository : IAcceptedOrdersRepository
{
    private readonly APhotosContext _context;

    public AcceptedOrdersRepository(APhotosContext context)
    {
        _context = context;
    }
    
    public Task<List<AcceptedOrder>> GetAllAcceptedOrders()
    {
        return _context.AcceptedOrders.ToListAsync();
    }
    public void AddAcceptedOrder(AcceptedOrder acceptedOrder)
    {
        _context.AcceptedOrders.Add(acceptedOrder);
        _context.SaveChanges();
    }
    
    public void FinishOrder(AcceptedOrder order)
    {
        order.IsFinished = true;
    }
    
    public AcceptedOrder GetOrderById(uint orderId)
    {
        return _context.AcceptedOrders.FirstOrDefault(o => o.Id == orderId);
    }
}