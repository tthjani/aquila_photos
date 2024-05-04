using APhoto.Api.Data;
using APhoto.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace APhoto.Api.Services.Repository;

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