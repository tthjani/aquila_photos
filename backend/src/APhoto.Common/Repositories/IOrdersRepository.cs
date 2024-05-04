using APhoto.Data;

namespace APhoto.Common.Repositories;

public interface IOrdersRepository
{
    Task<List<Order>> GetAllOrders();
    void Add(Order order);
    void DeleteOrder(Order order);
    void AcceptOrder(Order order);
    void DeclineOrder(Order order);
    Order GetOrderById(uint orderId);
    void UpdateOrder(Order order);
}