﻿
using APhoto_backend.Data;
using APhoto_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace APhoto_backend.Services.Repository;

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
}