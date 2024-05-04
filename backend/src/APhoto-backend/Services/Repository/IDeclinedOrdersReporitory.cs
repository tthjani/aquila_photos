using APhoto.Api.Models;

namespace APhoto.Api.Services.Repository;

public interface IDeclinedOrdersReporitory
{
    Task<List<DeclinedOrder>> GetAllDeclinedOrders();
    void AddDeclinedOrder(DeclinedOrder declinedOrder);
}