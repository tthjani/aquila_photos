using APhoto_backend.Models;

namespace APhoto_backend.Services.Repository;

public interface IAcceptedOrdersRepository
{
    Task<List<AcceptedOrder>> GetAllAcceptedOrders();
    void AddAcceptedOrder(AcceptedOrder acceptedOrder);
    AcceptedOrder GetOrderById(uint orderId);
    void FinishOrder(AcceptedOrder accOrder);
}