using APhoto_backend.Data;
using APhoto_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace APhoto_backend.Services.Repository;

public class FinishedOrdersRepository : IFinishedOrdersRepository
{
    private readonly APhotosContext _context;

    public FinishedOrdersRepository(APhotosContext context)
    {
        _context = context;
    }
    
    public Task<List<FinishedOrder>> GetAllFinishedOrders()
    {
        return _context.FinishedOrders.ToListAsync();
    }
    public void AddFinishedOrder(FinishedOrder finishedOrder)
    {
        _context.FinishedOrders.Add(finishedOrder);
        _context.SaveChanges();
    }
}