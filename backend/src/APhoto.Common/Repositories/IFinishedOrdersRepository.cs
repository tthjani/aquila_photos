using APhoto.Data;

namespace APhoto.Common.Repositories;

public interface IFinishedOrdersRepository
{
    Task<List<FinishedOrder>> GetAllFinishedOrders();
    void AddFinishedOrder(FinishedOrder finishedOrder);
}