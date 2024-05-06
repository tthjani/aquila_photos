using APhoto.Api.Requests;
using APhoto.Api.Services;
using APhoto.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APhoto.Api.Controllers;

[ApiController]
[Route("/api/[controller]/[action]")]
public class OrderController : CustomControllerBase<OrderController>
{
    private readonly IOrdersService _ordersService;

    public OrderController(ILogger<OrderController> logger, IOrdersService ordersService)
        : base(logger)
    {
        _ordersService = ordersService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IAsyncEnumerable<Order>), StatusCodes.Status200OK)]
    public IAsyncEnumerable<Order> GetAllOrders(CancellationToken cancellationToken)
    {
        return _ordersService.GetOrdersAsync(cancellationToken);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Accepted), StatusCodes.Status202Accepted)]
    public async Task<IActionResult> AddOrder(AddOrderRequestV1 request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var result = await _ordersService.CreateOrderAsync(request, cancellationToken);

        if (result.IsFailure)
        {
            return Problem(result.Reason);
        }

        return Accepted();
    }

    [HttpGet]
    [ProducesResponseType(typeof(IAsyncEnumerable<Order>), StatusCodes.Status200OK)]
    public IAsyncEnumerable<Order> GetAllAcceptedOrders(CancellationToken cancellationToken)
    {
        return _ordersService.GetAcceptedOrdersAsync(cancellationToken);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
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
            return ValidationProblem(result.Reason);
        }

        return Accepted();
    }

    [HttpGet]
    [ProducesResponseType(typeof(IAsyncEnumerable<Order>), StatusCodes.Status200OK)]
    public IAsyncEnumerable<Order> GetAllDeclinedOrders(CancellationToken cancellationToken)
    {
        return _ordersService.GetDeclinedOrdersAsync(cancellationToken);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
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
            return ValidationProblem(result.Reason);
        }

        return Accepted();
    }

    [HttpGet]
    [ProducesResponseType(typeof(IAsyncEnumerable<Order>), StatusCodes.Status200OK)]
    public IAsyncEnumerable<Order> GetAllFinishedOrders(CancellationToken cancellationToken)
    {
        return _ordersService.GetFinishedOrdersAsync(cancellationToken);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
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
            return ValidationProblem(result.Reason);
        }

        return Accepted();
    }
}