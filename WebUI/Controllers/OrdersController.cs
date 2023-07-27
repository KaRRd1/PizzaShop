using Application.Dtos;
using Application.Dtos.Order;
using Application.Interfaces.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebUI.Extensions;

namespace WebUI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderRequest request, 
        [FromServices]IValidator<CreateOrderRequest> validator, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var modelStateDictionary = new ModelStateDictionary();
            validationResult.AddToModelState(modelStateDictionary);
            
            return ValidationProblem(modelStateDictionary);
        }


        var loggedInUserId = HttpContext.User.Identity?.NameToInt();
        
        return Ok(await _orderService.CreateOrder(request, loggedInUserId, cancellationToken));
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Me(int page, CancellationToken cancellationToken)
    {
        var userId = HttpContext.User.Identity!.NameToInt()!.Value;
        
        return Ok(await _orderService.GetUserOrders(userId, page, cancellationToken));
    }
}