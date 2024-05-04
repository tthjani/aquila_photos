using APhoto.Data;
using Microsoft.EntityFrameworkCore;

namespace APhoto.Common.Repositories;

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