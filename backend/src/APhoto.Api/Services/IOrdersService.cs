using APhoto.Api.Requests;
using APhoto.Data;
using APhoto.Infrastructure.ServiceResult;

namespace APhoto.Api.Services
{
    public interface IOrdersService
    {
        IAsyncEnumerable<Order> GetOrdersAsync(CancellationToken cancellationToken);

        Task<Order> CreateOrderAsync(AddOrderRequestV1 request, CancellationToken cancellationToken);

        IAsyncEnumerable<AcceptedOrder> GetAcceptedOrdersAsync(CancellationToken cancellationToken);

        Task<IServiceResult> AcceptOrderAsync(AcceptOrderRequestV1 request, CancellationToken cancellationToken);

        IAsyncEnumerable<DeclinedOrder> GetDeclinedOrdersAsync(CancellationToken cancellationToken);

        Task<IServiceResult> DeclineOrderAsync(DeclineOrderRequestV1 request, CancellationToken cancellationToken);

        IAsyncEnumerable<FinishedOrder> GetFinishedOrdersAsync(CancellationToken cancellationToken);

        Task<IServiceResult> FinishOrderAsync(FinishOrderRequestV1 request, CancellationToken cancellationToken);
    }
}
