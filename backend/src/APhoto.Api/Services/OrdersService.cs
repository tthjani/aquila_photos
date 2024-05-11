using APhoto.Api.Requests;
using APhoto.Common;
using APhoto.Common.Repositories;
using APhoto.Data;
using APhoto.Infrastructure;
using APhoto.Infrastructure.Utility;
using AutoMapper;

namespace APhoto.Api.Services
{
    public class OrdersService(
        IMapper mapper,
        IAbstractRepository<Order> ordersRepository,
        IHolidayRepository holidayRepository) : IOrdersService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IAbstractRepository<Order> _ordersRepository = ordersRepository;
        private readonly IHolidayRepository _holidayRepository = holidayRepository;

        public IAsyncEnumerable<Order> GetOrdersAsync(CancellationToken cancellationToken)
            => _ordersRepository.GetManyAsync(order => order.OrderStatus == OrderStatus.Created.ToString(), cancellationToken);

        public async Task<IServiceResult> CreateOrderAsync(AddOrderRequestV1 request, CancellationToken cancellationToken)
        {
            try
            {
                if (_holidayRepository.IsDateInAnActiveHoliday(DateTime.Today))
                {
                    return ServiceResult.Fail("Creating new order is currently not allowed.");
                }
                
                var entity = _mapper.Map<Order>(request);
                entity.OrderStatus = OrderStatus.Created.ToString();

                await _ordersRepository.CreateAsync(entity, cancellationToken);
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail(ex.Message);
            }

            return ServiceResult.Success();
        }

        public IAsyncEnumerable<Order> GetAcceptedOrdersAsync(CancellationToken cancellationToken)
        {
            return _ordersRepository.GetManyAsync(x => x.OrderStatus == OrderStatus.Accepted.ToString(), cancellationToken);
        }

        public async Task<IServiceResult> AcceptOrderAsync(AcceptOrderRequestV1 request, CancellationToken cancellationToken)
        {
            var orderResult = await _ordersRepository.GetOneAsync(
                order => order.OrderId == request.OrderId
                    && order.OrderStatus == OrderStatus.Created.ToString(),
                cancellationToken);
            if (orderResult.IsFailure)
            {
                return ServiceResult.Fail("Order can not be found.");
            }

            await updateOrderStatus(orderResult.Value!, OrderStatus.Accepted, cancellationToken);

            return ServiceResult.Success();
        }

        public IAsyncEnumerable<Order> GetDeclinedOrdersAsync(CancellationToken cancellationToken)
        {
            return _ordersRepository.GetManyAsync(order => order.OrderStatus == OrderStatus.Declined.ToString(), cancellationToken);
        }

        public async Task<IServiceResult> DeclineOrderAsync(DeclineOrderRequestV1 request, CancellationToken cancellationToken)
        {
            var orderResult = await _ordersRepository.GetOneAsync(
                order => order.OrderId == request.OrderId
                    && order.OrderStatus == OrderStatus.Created.ToString()
                , cancellationToken);
            if (orderResult.IsFailure)
            {
                return ServiceResult.Fail("Order can not be found.");
            }

            var order = orderResult.Value!;
            order.RefusalReason = request.Reason;
            await updateOrderStatus(order, OrderStatus.Declined, cancellationToken);

            return ServiceResult.Success();
        }

        public IAsyncEnumerable<Order> GetFinishedOrdersAsync(CancellationToken cancellationToken)
        {
            return _ordersRepository.GetManyAsync(
                order => order.OrderStatus == OrderStatus.Finished.ToString(),
                cancellationToken);
        }

        public async Task<IServiceResult> FinishOrderAsync(FinishOrderRequestV1 request, CancellationToken cancellationToken)
        {
            var orderResult = await _ordersRepository.GetOneAsync(
                acceptedOrder => acceptedOrder.OrderId == request.OrderId
                    && acceptedOrder.OrderStatus == OrderStatus.Accepted.ToString(),
                cancellationToken);

            if (orderResult.IsFailure)
            {
                return ServiceResult.Fail("Accepted order can not be found.");
            }

            await updateOrderStatus(orderResult.Value!, OrderStatus.Finished, cancellationToken);

            return ServiceResult.Success();
        }

        private async Task updateOrderStatus(Order order, OrderStatus orderStatus, CancellationToken cancellationToken)
        {
            order.OrderStatus = orderStatus.ToString();
            order.LastModifiedAt = DateTime.UtcNow;

            await _ordersRepository.UpdateAsync(order, cancellationToken);
        }
    }
}
