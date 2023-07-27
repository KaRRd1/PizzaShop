using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientsController : ControllerBase
{
    private readonly IIngredientService _ingredientService;

    public IngredientsController(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        return Ok(await _ingredientService.GetCategoriesWithIngredients(cancellationToken));
    }
    
    [HttpGet("from")]
    public async Task<IActionResult> GetFromProductCategory([FromQuery, Required]int productCategoryId, CancellationToken cancellationToken)
    {
        return Ok(await _ingredientService.GetIngredientsFromProductCategory(productCategoryId, cancellationToken));
    }
}