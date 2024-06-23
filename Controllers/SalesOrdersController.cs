using ecommerce_v2.Models;
using ecommerce_v2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ecommerce_v2.Controllers;

public class SalesOrdersController(SalesOrderService salesOrderService) : ODataController
{
    [EnableQuery]
    public async Task<IActionResult> GetProducts()
    {
        var salesOrders = await salesOrderService.GetAll();
        return Ok(new { salesOrderItems = salesOrders });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var salesOrder = await salesOrderService.GetById(id);
        if (salesOrder == null) return NotFound();
        return Ok(salesOrder);
    }

    [HttpPost]
    public async Task<IActionResult> Add(SalesOrder salesOrder)
    {
        var salesOrderItemCreated = await salesOrderService.Add(salesOrder);
        return CreatedAtAction(nameof(GetById), new { id = salesOrderItemCreated.Id },
            salesOrderItemCreated);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, SalesOrder salesOrder)
    {
        if (id != salesOrder.Id) return BadRequest();
        var salesOrderUpdated = await salesOrderService.Update(salesOrder);
        return Ok(salesOrderUpdated);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await salesOrderService.Delete(id);
        return NoContent();
    }
}