using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoriesController:ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoriesController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpPost]
    [Route("/createCategory")]
    public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
    {
        //Map dto to domain model

        var category = new Category()
        {
            Name = request.Name,
            UrlHandle = request.UrlHandle
        };
        await _categoryRepository.CreateAsync(category);
        
        //domain model to dto
        var response = new CategoryDto()
        {
            Id = category.Id,
            Name = category.Name,
            UrlHandle = category.UrlHandle
        };
        return Ok(response);
    }
    
    
}