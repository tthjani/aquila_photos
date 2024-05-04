using APhoto.Api.Models;

namespace APhoto.Api.Services.Repository;

public interface IFinishedOrdersRepository
{
    Task<List<FinishedOrder>> GetAllFinishedOrders();
    void AddFinishedOrder(FinishedOrder finishedOrder);
}