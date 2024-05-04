using APhoto.Api.Requests;
using APhoto.Common.Repositories;
using APhoto.Data;
using APhoto.Infrastructure;
using APhoto.Infrastructure.ServiceResult;
using AutoMapper;

namespace APhoto.Api.Services
{
    public class OrderService : IOrdersService
    {
        private readonly IMapper _mapper;
        private readonly IAbstractRepository<Order> _ordersRepository;
        private readonly IAbstractRepository<AcceptedOrder> _acceptedOrderRepository;
        private readonly IAbstractRepository<DeclinedOrder> _declinedOrdersReporitory;
        private readonly IAbstractRepository<FinishedOrder> _finishedOrdersRepository;

        public OrderService(
            IMapper mapper,
            IAbstractRepository<Order> ordersRepository,
            IAbstractRepository<AcceptedOrder> acceptedOrderRepository,
            IAbstractRepository<DeclinedOrder> declinedOrdersReporitory,
            IAbstractRepository<FinishedOrder> finishedOrdersRepository)
        {
            _mapper = mapper;
            _ordersRepository = ordersRepository;
            _acceptedOrderRepository = acceptedOrderRepository;
            _declinedOrdersReporitory = declinedOrdersReporitory;
            _finishedOrdersRepository = finishedOrdersRepository;
        }

        public IAsyncEnumerable<Order> GetOrdersAsync(CancellationToken cancellationToken)
        {
            return _ordersRepository.GetAllAsync(cancellationToken);
        }

        public async Task<Order> CreateOrderAsync(AddOrderRequestV1 request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Order>(request);

            await _ordersRepository.CreateAsync(entity, cancellationToken);

            return entity;
        }

        public IAsyncEnumerable<AcceptedOrder> GetAcceptedOrdersAsync(CancellationToken cancellationToken)
        {
            return _acceptedOrderRepository.GetAllAsync(cancellationToken);
        }

        public async Task<IServiceResult> AcceptOrderAsync(AcceptOrderRequestV1 request, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.GetOneAsync(order => order.Id == request.OrderId, cancellationToken);
            if (order == null)
            {
                return ServiceResult.Fail("Order can not be found.");
            }
            order.IsAccepted = true;
            await _ordersRepository.UpdateAsync(order, cancellationToken);

            var acceptedOrder = new AcceptedOrder
            {
                OrderId = order.Id,
                AcceptanceDate = DateTime.UtcNow
            };

            await _acceptedOrderRepository.CreateAsync(acceptedOrder, cancellationToken);

            return ServiceResult.Success();
        }

        public IAsyncEnumerable<DeclinedOrder> GetDeclinedOrdersAsync(CancellationToken cancellationToken)
        {
            return _declinedOrdersReporitory.GetAllAsync(cancellationToken);
        }

        public async Task<IServiceResult> DeclineOrderAsync(DeclineOrderRequestV1 request, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.GetOneAsync(order => order.Id == request.OrderId, cancellationToken);
            if (order == null)
            {
                return ServiceResult.Fail("Order can not be found.");
            }

            var declinedOrder = new DeclinedOrder
            {
                OrderId = request.OrderId,
                Reason = request.Reason
            };

            await _declinedOrdersReporitory.CreateAsync(declinedOrder, cancellationToken);

            return ServiceResult.Success();
        }

        public IAsyncEnumerable<FinishedOrder> GetFinishedOrdersAsync(CancellationToken cancellationToken)
        {
            return _finishedOrdersRepository.GetAllAsync(cancellationToken);
        }

        public async Task<IServiceResult> FinishOrderAsync(FinishOrderRequestV1 request, CancellationToken cancellationToken)
        {
            var accOrder = await _acceptedOrderRepository.GetOneAsync(acceptedOrder => acceptedOrder.Id == request.AcceptedOrderId, cancellationToken);
            if (accOrder == null)
            {
                return ServiceResult.Fail("Accepted order can not be found.");
            }

            var finishedOrder = new FinishedOrder
            {
                AcceptedId = accOrder.Id,
                FinishDate = DateTime.UtcNow,
                OrderId = accOrder.OrderId
            };

            await _finishedOrdersRepository.CreateAsync(finishedOrder, cancellationToken);

            return ServiceResult.Success();
        }
    }
}
