using System.Security.Claims;
using Application.Dtos;
using Application.Dtos.Order;
using Application.Dtos.User;
using Application.Interfaces.Services;
using Application.Validations.User;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebUI.Extensions;

namespace WebUI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AccountController : ControllerBase
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginUserRequest request, 
        [FromServices]IValidator<LoginUserRequest> validator, CancellationToken cancellationToken)
    {
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            var modelStateDictionary = new ModelStateDictionary();
            validationResult.AddToModelState(modelStateDictionary);

            return ValidationProblem(modelStateDictionary);
        }

        var user = await _userService.GetOrCreateUser(request, cancellationToken);

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Id.ToString()),
        };

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties { IsPersistent = true };

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity), authProperties);

        return Ok(user);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Info(CancellationToken cancellationToken)
    {
        var userId = HttpContext.User.Identity!.NameToInt()!.Value;
        var user = await _userService.GetUser(userId, cancellationToken);

        return Ok(user);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Update(UpdateUserRequest request,[FromServices]IValidator<UpdateUserRequest> validator, CancellationToken cancellationToken)
    {
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            var modelStateDictionary = new ModelStateDictionary();
            validationResult.AddToModelState(modelStateDictionary);

            return ValidationProblem(modelStateDictionary);
        }
        
        var userId = HttpContext.User.Identity!.NameToInt()!.Value;
        var updatedUser = await _userService.UpdateUser(userId, request, cancellationToken);

        return Ok(updatedUser);
    }
    
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        
        return Ok();
    }
}