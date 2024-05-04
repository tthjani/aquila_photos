using APhoto.Data;

namespace APhoto.Common.Repositories;

public interface IAcceptedOrdersRepository
{
    Task<List<AcceptedOrder>> GetAllAcceptedOrders();
    void AddAcceptedOrder(AcceptedOrder acceptedOrder);
    AcceptedOrder GetOrderById(uint orderId);
    void FinishOrder(AcceptedOrder accOrder);
}