using Microsoft.AspNetCore.Mvc;
using TESTAPI.Data;
using TESTAPI.DTO;
using TESTAPI.Models;
using TESTAPI.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class BrandController : ControllerBase
{
    private readonly AppDbContext _context;

    public BrandController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetBrands()
    {
        var brands = _context.Brands
            .Select(b => new BrandDTO
            {
                Id = b.Id,
                BrandName = b.BrandName,
                Country = b.Country,
                Flag = b.Flag
            }).ToList();
        return Ok(brands);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBrandById(int id)
    {
        var b = _context.Brands.Find(id);
        if (b == null) return NotFound();

        return Ok(new BrandDTO
        {
            Id = b.Id,
            BrandName = b.BrandName,
            Country = b.Country,
            Flag = b.Flag
        });
    }

    [HttpPost]
    public async Task<IActionResult> AddBrand(BrandDTO dto)
    {
        var brand = new Brand
        {
            BrandName = dto.BrandName,
            Country = dto.Country,
            Flag = dto.Flag
        };
        await _context.Brands.AddAsync(brand);
        await _context.SaveChangesAsync();

        dto.Id = brand.Id;
        return CreatedAtAction(nameof(GetBrandById), new { id = brand.Id }, dto);
    }
}
