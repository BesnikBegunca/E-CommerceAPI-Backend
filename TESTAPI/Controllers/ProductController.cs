using Microsoft.AspNetCore.Mvc;
using TESTAPI.Data;
using TESTAPI.Models;
using TESTAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _context.Products
            .Include(p => p.Brand)
            .Include(p => p.Category)
            .Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                ImagePath = p.ImagePath,
                Description = p.Description,
                AdditionalDescription = p.AdditionalDescription,
                BrandId = p.BrandId,
                CategoryId = p.CategoryId,
                BrandName = p.Brand.BrandName,
                CategoryName = p.Category.CategoryName
            }).ToListAsync();

        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(ProductDTO dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            ImagePath = dto.ImagePath,
            Description = dto.Description,
            AdditionalDescription = dto.AdditionalDescription,
            BrandId = dto.BrandId,
            CategoryId = dto.CategoryId
        };

        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        dto.Id = product.Id;
        return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, dto);
    }
}
