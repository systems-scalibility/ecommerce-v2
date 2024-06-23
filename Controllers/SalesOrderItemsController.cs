using ecommerce_v2.Models;
using ecommerce_v2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ecommerce_v2.Controllers;

public class SalesOrderItemsController(SalesOrderItemService salesOrderItemService) : ODataController
{
    [EnableQuery(PageSize = 10)]
    public ActionResult<IQueryable> GetSalesOrderItems()
    {
        var salesOrderItems = salesOrderItemService.GetAll();
        return Ok(salesOrderItems);
    }

    public async Task<IActionResult> GetSalesOrderItem(int key)
    {
        var salesOrderItem = await salesOrderItemService.GetById(key);
        if (salesOrderItem == null) return NotFound();
        return Ok(salesOrderItem);
    }

    public async Task<IActionResult> Post(SalesOrderItem salesOrderItem)
    {
        var salesOrderItemCreated = await salesOrderItemService.Add(salesOrderItem);
        return CreatedAtAction(nameof(GetSalesOrderItem), new { id = salesOrderItemCreated.Id },
            salesOrderItemCreated);
    }

    public async Task<IActionResult> Put(int key, SalesOrderItem salesOrderItem)
    {
        if (key != salesOrderItem.Id) return BadRequest();
        var salesOrderItemUpdated = await salesOrderItemService.Update(salesOrderItem);
        return Ok(salesOrderItemUpdated);
    }

    public async Task<IActionResult> Delete(int key)
    {
        await salesOrderItemService.DeleteById(key);
        return NoContent();
    }
}