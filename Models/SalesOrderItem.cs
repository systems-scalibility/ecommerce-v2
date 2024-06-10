using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_v1.Models;

public class SalesOrderItem
{
    [Column("Id")] public int SalesOrderItemId { get; set; }
    public int SalesOrderId { get; set; }
    public int ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Quantity { get; set; }
    public decimal Total { get; set; }
    public Guid RowGuid { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }

    public SalesOrder? SalesOrder { get; set; }
    public Product? Product { get; set; }
}