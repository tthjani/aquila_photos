using APhoto.Api.Requests;
using APhoto.Data;
using APhoto.Infrastructure.Utility;

namespace APhoto.Api.Services
{
    public interface IOrdersService
    {
        IAsyncEnumerable<Order> GetOrdersAsync(CancellationToken cancellationToken);

        Task<IServiceResult> CreateOrderAsync(AddOrderRequestV1 request, CancellationToken cancellationToken);

        IAsyncEnumerable<Order> GetAcceptedOrdersAsync(CancellationToken cancellationToken);

        Task<IServiceResult> AcceptOrderAsync(AcceptOrderRequestV1 request, CancellationToken cancellationToken);

        IAsyncEnumerable<Order> GetDeclinedOrdersAsync(CancellationToken cancellationToken);

        Task<IServiceResult> DeclineOrderAsync(DeclineOrderRequestV1 request, CancellationToken cancellationToken);

        IAsyncEnumerable<Order> GetFinishedOrdersAsync(CancellationToken cancellationToken);

        Task<IServiceResult> FinishOrderAsync(FinishOrderRequestV1 request, CancellationToken cancellationToken);
    }
}
