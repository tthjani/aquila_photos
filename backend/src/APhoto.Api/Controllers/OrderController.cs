using APhoto.Data;
using APhoto.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace APhoto.Api.Controllers;

[ApiController]
[Route("/api/[controller]/[action]")]
public class OrderController : ControllerBase
{
    private readonly IAbstractRepository<Order> _ordersRepository;
    private readonly IAbstractRepository<AcceptedOrder> _acceptedOrdersRepository;
    private readonly IAbstractRepository<DeclinedOrder> _declinedOrdersReporitory;
    private readonly IAbstractRepository<FinishedOrder> _finishedOrdersRepository;

    public OrderController(IAbstractRepository<Order> ordersRepository, IAbstractRepository<AcceptedOrder> acceptedOrderRepository, IAbstractRepository<DeclinedOrder> declinedOrdersReporitory, IAbstractRepository<FinishedOrder> finishedOrdersRepository)
    {
        _ordersRepository = ordersRepository;
        _acceptedOrdersRepository = acceptedOrderRepository;
        _declinedOrdersReporitory = declinedOrdersReporitory;
        _finishedOrdersRepository = finishedOrdersRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders(CancellationToken cancellationToken)
    {
        var respond = new { res = _ordersRepository.GetAll(cancellationToken) };
        return Ok(respond);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddOrder(Order order, CancellationToken cancellationToken)
    {
        try
        {
            if (order == null)
            {
                return BadRequest("Please add a valid Order");
            }
            
            await _ordersRepository.Create(order, cancellationToken);
            var response = new { res = order };
            return Accepted(response);
        }
        
        catch
        {
            return StatusCode(500, "An error occured");
        }      
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAcceptedOrders(CancellationToken cancellationToken)
    {
        var res = _acceptedOrdersRepository.GetAll(cancellationToken);
        var respond = new { res };
        return Ok(respond);
    }
    
    [HttpPost]
    public async Task<IActionResult> AcceptOrder(uint orderId, CancellationToken cancellationToken)
    {
        var order = await _ordersRepository.GetOne(order => order.Id == orderId, cancellationToken);
        if (order == null)
        {
            return NotFound();
        }
        order.IsAccepted = true;
        await _ordersRepository.Update(order, cancellationToken);

        var acceptedOrder = new AcceptedOrder
        {
            OrderId = orderId,
            AcceptanceDate = DateTime.UtcNow
        };
        
        await _acceptedOrdersRepository.Create(acceptedOrder, cancellationToken);

        return Accepted();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllDeclinedOrders(CancellationToken cancellationToken)
    {
        var res = _declinedOrdersReporitory.GetAll(cancellationToken);
        var respond = new { res };
        return Ok(respond);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeclineOrder(uint orderId, string reason, CancellationToken cancellationToken)
    {
        var order = await _ordersRepository.GetOne(order => order.Id == orderId, cancellationToken);
        if (order == null)
        {
            return NotFound();
        }

        var declinedOrder = new DeclinedOrder
        {
            OrderId = orderId,
            Reason = reason
        };
        await _declinedOrdersReporitory.Create(declinedOrder, cancellationToken);

        return Accepted();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllFinishedOrders(CancellationToken cancellationToken)
    {
        var res = _finishedOrdersRepository.GetAll(cancellationToken);
        var respond = new { res };
        return Ok(respond);
    }
    
    [HttpPost]
    public async Task<IActionResult> FinishOrder(uint accOrderId, CancellationToken cancellationToken)
    {
        var accOrder = await _acceptedOrdersRepository.GetOne(acceptedOrder => acceptedOrder.Id == accOrderId, cancellationToken);
        if (accOrder == null)
        {
            return NotFound();
        }

        var finishedOrder = new FinishedOrder
        {
            AcceptedId = accOrderId,
            FinishDate = DateTime.UtcNow,
            OrderId = accOrder.OrderId
        };
        await _finishedOrdersRepository.Create(finishedOrder, cancellationToken);

        return Accepted();
    }
}