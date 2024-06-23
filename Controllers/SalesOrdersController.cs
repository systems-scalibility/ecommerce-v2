using ecommerce_v2.Models;
using ecommerce_v2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ecommerce_v2.Controllers;

public class SalesOrdersController(SalesOrderService salesOrderService) : ODataController
{
    [EnableQuery(PageSize = 10)]
    public ActionResult<IQueryable> GetSalesOrders()
    {
        var salesOrders = salesOrderService.GetAll();
        return Ok(salesOrders);
    }

    [EnableQuery]
    public async Task<IActionResult> GetSalesOrder([FromRoute] int key)
    {
        var salesOrder = await salesOrderService.GetById(key);
        if (salesOrder == null) return NotFound();
        return Ok(salesOrder);
    }

    public async Task<IActionResult> Posts([FromBody] SalesOrder salesOrder)
    {
        var salesOrderItemCreated = await salesOrderService.Add(salesOrder);
        return CreatedAtAction(nameof(GetSalesOrder), new { id = salesOrderItemCreated.Id },
            salesOrderItemCreated);
    }

    public async Task<IActionResult> Put([FromRoute] int key, [FromBody] SalesOrder salesOrder)
    {
        if (key != salesOrder.Id) return BadRequest();
        var salesOrderUpdated = await salesOrderService.Update(salesOrder);
        return Ok(salesOrderUpdated);
    }

    public async Task<IActionResult> Delete([FromRoute] int key)
    {
        await salesOrderService.DeleteById(key);
        return NoContent();
    }
}