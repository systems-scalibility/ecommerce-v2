using ecommerce_v2.Models;
using ecommerce_v2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ecommerce_v2.Controllers;

public class ProductsController(ProductService productService) : ODataController
{
    [EnableQuery]
    public ActionResult<IQueryable> GetProducts()
    {
        var products = productService.GetAll();
        return Ok(products);
    }

    public async Task<IActionResult> GetById(int id)
    {
        var product = await productService.GetById(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    public async Task<IActionResult> Add(Product product)
    {
        var productCreated = await productService.Add(product);
        return CreatedAtAction(nameof(GetById), new { id = productCreated.Id }, productCreated);
    }

    public async Task<IActionResult> Update(int id, Product product)
    {
        if (id != product.Id) return BadRequest();
        var productUpdated = await productService.Update(product);
        return Ok(productUpdated);
    }

    public async Task<IActionResult> Delete(int id)
    {
        await productService.DeleteById(id);
        return NoContent();
    }
}