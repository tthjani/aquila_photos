using APhoto_backend.Models;

namespace APhoto_backend.Services.Repository;

public interface IFinishedOrdersRepository
{
    Task<List<FinishedOrder>> GetAllFinishedOrders();
    void AddFinishedOrder(FinishedOrder finishedOrder);
}