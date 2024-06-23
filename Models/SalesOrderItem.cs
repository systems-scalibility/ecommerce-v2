using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_v2.Models;

[Table("SalesOrderItem")]
public class SalesOrderItem : Base
{
    public int SalesOrderId { get; set; }
    public int ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Quantity { get; set; }
    public decimal Total { get; set; }

    public SalesOrder? SalesOrder { get; set; }
    public Product? Product { get; set; }
}