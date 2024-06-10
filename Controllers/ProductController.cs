using ecommerce_v1.Models;
using ecommerce_v1.Services;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_v1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(ProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await productService.GetAll();
        return Ok(new { products });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await productService.GetById(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Add(Product product)
    {
        var productCreated = await productService.Add(product);
        return CreatedAtAction(nameof(GetById), new { id = productCreated.ProductId }, productCreated);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Product product)
    {
        if (id != product.ProductId) return BadRequest();
        var productUpdated = await productService.Update(product);
        return Ok(productUpdated);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await productService.Delete(id);
        return NoContent();
    }
}