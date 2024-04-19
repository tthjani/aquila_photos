using APhoto_backend.Models;
using APhoto_backend.Services.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APhoto_backend.Controllers;

[ApiController]
[Route("/api/[controller]/[action]")]
public class OrderController : ControllerBase
{
    private readonly IOrdersRepository _ordersRepository;

    public OrderController(IOrdersRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
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
                return BadRequest("Please add a valid Applicant");
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
}