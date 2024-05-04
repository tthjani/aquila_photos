using APhoto.Api.Data;
using APhoto.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace APhoto.Api.Services.Repository;

public class DeclinedOrdersRepository : IDeclinedOrdersReporitory
{
    private readonly APhotosContext _context;

    public DeclinedOrdersRepository(APhotosContext context)
    {
        _context = context;
    }
    
    public Task<List<DeclinedOrder>> GetAllDeclinedOrders()
    {
        return _context.DeclinedOrders.ToListAsync();
    }
    public void AddDeclinedOrder(DeclinedOrder declinedOrder)
    {
        _context.DeclinedOrders.Add(declinedOrder);
        _context.SaveChanges();
    }
}