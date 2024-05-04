using APhoto.Api.Models;

namespace APhoto.Api.Services.Repository;

public interface IAcceptedOrdersRepository
{
    Task<List<AcceptedOrder>> GetAllAcceptedOrders();
    void AddAcceptedOrder(AcceptedOrder acceptedOrder);
    AcceptedOrder GetOrderById(uint orderId);
    void FinishOrder(AcceptedOrder accOrder);
}