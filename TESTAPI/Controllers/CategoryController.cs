using Microsoft.AspNetCore.Mvc;
using TESTAPI.Data;
using TESTAPI.DTO;
using TESTAPI.Models;
using TESTAPI.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoryController(AppDbContext context) => _context = context;

    [HttpGet]
    public IActionResult GetCategories() =>
        Ok(_context.Categories.Select(c => new CategoryDTO
        {
            Id = c.Id,
            CategoryName = c.CategoryName
        }).ToList());

    [HttpPost]
    public async Task<IActionResult> AddCategory(CategoryDTO dto)
    {
        var category = new Category { CategoryName = dto.CategoryName };
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();

        dto.Id = category.Id;
        return CreatedAtAction(nameof(GetCategories), new { id = category.Id }, dto);
    }
}
