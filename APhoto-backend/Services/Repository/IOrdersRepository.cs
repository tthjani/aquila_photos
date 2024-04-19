using APhoto_backend.Models;

namespace APhoto_backend.Services.Repository;

public interface IOrdersRepository
{
    Task<List<Order>> GetAllOrders();
    void Add(Order order);
}