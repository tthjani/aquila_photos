using APhoto_backend.Models;
using APhoto_backend.Services.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APhoto_backend.Controllers;

[ApiController]
[Route("/api/[controller]/[action]")]
public class OrderController : ControllerBase
{
    private readonly IOrdersRepository _ordersRepository;
    private readonly IAcceptedOrdersRepository _acceptedOrdersRepository;
    private readonly IDeclinedOrdersReporitory _declinedOrdersReporitory;
    private readonly IFinishedOrdersRepository _finishedOrdersRepository;

    public OrderController(IOrdersRepository ordersRepository, IAcceptedOrdersRepository acceptedOrderRepository, IDeclinedOrdersReporitory declinedOrdersReporitory, IFinishedOrdersRepository finishedOrdersRepository)
    {
        _ordersRepository = ordersRepository;
        _acceptedOrdersRepository = acceptedOrderRepository;
        _declinedOrdersReporitory = declinedOrdersReporitory;
        _finishedOrdersRepository = finishedOrdersRepository;
    }

    [HttpGet]
    public ActionResult GetAllOrders()
    {
        var respond = new { res = _ordersRepository.GetAllOrders() };
        return Ok(respond);
    }
    
    [HttpPost]
    public ActionResult AddOrder(Order order)
    {
        try
        {
            if (order == null)
            {
                return BadRequest("Please add a valid Order");
            }
            
            _ordersRepository.Add(order);
            var response = new { res = order };
            return Ok(response);
        }
        
        catch (Exception e)
        {
            return StatusCode(500, "An error occured");
        }      
    }
    
    [HttpGet]
    public ActionResult GetAllAcceptedOrders()
    {
        var respond = new { res = _acceptedOrdersRepository.GetAllAcceptedOrders() };
        return Ok(respond);
    }
    
    [HttpPost]
    public IActionResult AcceptOrder(uint orderId)
    {
        var order = _ordersRepository.GetOrderById(orderId);
        if (order == null)
        {
            return NotFound();
        }
        order.IsAccepted = true;
        _ordersRepository.UpdateOrder(order);

        var acceptedOrder = new AcceptedOrder
        {
            OrderId = orderId,
            AcceptanceDate = DateTime.Now
        };
        
        _acceptedOrdersRepository.AddAcceptedOrder(acceptedOrder);

        return Ok();
    }
    
    [HttpGet]
    public ActionResult GetAllDeclinedOrders()
    {
        var respond = new { res = _declinedOrdersReporitory.GetAllDeclinedOrders() };
        return Ok(respond);
    }
    
    [HttpPost]
    public IActionResult DeclineOrder(uint orderId, string reason)
    {
        var order = _ordersRepository.GetOrderById(orderId);
        if (order == null)
        {
            return NotFound();
        }

        var declinedOrder = new DeclinedOrder
        {
            Reason = reason
        };
        _declinedOrdersReporitory.AddDeclinedOrder(declinedOrder);

        return Ok();
    }
    
    [HttpGet]
    public ActionResult GetAllFinishedOrders()
    {
        var respond = new { res = _finishedOrdersRepository.GetAllFinishedOrders() };
        return Ok(respond);
    }
    
    [HttpPost]
    public IActionResult FinishOrder(uint accOrderId)
    {
        var accOrder = _acceptedOrdersRepository.GetOrderById(accOrderId);
        if (accOrder == null)
        {
            return NotFound();
        }

        var finishedOrder = new FinishedOrder();
        _finishedOrdersRepository.AddFinishedOrder(finishedOrder);

        return Ok();
    }
}