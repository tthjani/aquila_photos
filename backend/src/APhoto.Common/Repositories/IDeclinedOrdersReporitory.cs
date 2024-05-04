using APhoto.Data;

namespace APhoto.Common.Repositories;

public interface IDeclinedOrdersReporitory
{
    Task<List<DeclinedOrder>> GetAllDeclinedOrders();
    void AddDeclinedOrder(DeclinedOrder declinedOrder);
}