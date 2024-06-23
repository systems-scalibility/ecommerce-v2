using ecommerce_v2.Models;
using ecommerce_v2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ecommerce_v2.Controllers;

public class ProductsController(ProductService productService) : ODataController
{
    [EnableQuery(PageSize = 10)]
    public ActionResult<IQueryable> GetProducts()
    {
        var products = productService.GetAll();
        return Ok(products);
    }

    [EnableQuery]
    public async Task<IActionResult> GetProduct([FromRoute] int key)
    {
        var product = await productService.GetById(key);
        if (product == null) return NotFound();
        return Ok(product);
    }

    public async Task<IActionResult> Post([FromBody] Product product)
    {
        var productCreated = await productService.Add(product);
        return CreatedAtAction(nameof(GetProduct), new { id = productCreated.Id }, productCreated);
    }

    public async Task<IActionResult> Put([FromRoute] int key, [FromBody] Product product)
    {
        if (key != product.Id) return BadRequest();
        var productUpdated = await productService.Update(product);
        return Ok(productUpdated);
    }

    public async Task<IActionResult> Delete(int key)
    {
        await productService.DeleteById(key);
        return NoContent();
    }
}