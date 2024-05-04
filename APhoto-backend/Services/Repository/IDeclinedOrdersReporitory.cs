using APhoto_backend.Models;

namespace APhoto_backend.Services.Repository;

public interface IDeclinedOrdersReporitory
{
    Task<List<DeclinedOrder>> GetAllDeclinedOrders();
    void AddDeclinedOrder(DeclinedOrder declinedOrder);
}