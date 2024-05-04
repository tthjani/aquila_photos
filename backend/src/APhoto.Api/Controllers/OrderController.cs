using APhoto.Api.Requests;
using APhoto.Api.Services;
using APhoto.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APhoto.Api.Controllers;

[ApiController]
[Route("/api/[controller]/[action]")]
public class OrderController : ControllerBase
{
    private readonly IOrdersService _ordersService;

    public OrderController(IOrdersService ordersService)
    {
        _ordersService = ordersService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(Ok<IEnumerable<Order>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllOrders(CancellationToken cancellationToken)
    {
        var result = _ordersService.GetOrdersAsync(cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Accepted<Order>), StatusCodes.Status202Accepted)]
    public async Task<IActionResult> AddOrder(AddOrderRequestV1 request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var result = await _ordersService.CreateOrderAsync(request, cancellationToken);
        return Accepted(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(Ok<IEnumerable<AcceptedOrder>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAcceptedOrders(CancellationToken cancellationToken)
    {
        var result = _ordersService.GetAcceptedOrdersAsync(cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AcceptOrder([FromBody] AcceptOrderRequestV1 request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var result = await _ordersService.AcceptOrderAsync(request, cancellationToken);

        if (result.IsFailure)
        {
            return Problem(result.Reason);
        }

        return Accepted();
    }

    [HttpGet]
    [ProducesResponseType(typeof(Ok<IEnumerable<DeclinedOrder>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllDeclinedOrders(CancellationToken cancellationToken)
    {
        var result = _ordersService.GetDeclinedOrdersAsync(cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeclineOrder(DeclineOrderRequestV1 request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var result = await _ordersService.DeclineOrderAsync(request, cancellationToken);

        if (result.IsFailure)
        {
            return Problem(result.Reason);
        }

        return Accepted();
    }

    [HttpGet]
    [ProducesResponseType(typeof(Ok<IEnumerable<FinishedOrder>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllFinishedOrders(CancellationToken cancellationToken)
    {
        var result = _ordersService.GetFinishedOrdersAsync(cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> FinishOrder(FinishOrderRequestV1 request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var result = await _ordersService.FinishOrderAsync(request, cancellationToken);

        if (result.IsFailure)
        {
            return Problem(result.Reason);
        }

        return Accepted();
    }
}