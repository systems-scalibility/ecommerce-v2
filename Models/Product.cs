using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_v1.Models;

[Table("Product")]
public class Product
{
    [Column("Id")] public int ProductId { get; set; }
    [Column("ProductName")] public string? Name { get; set; }
    public string? CodeNumber { get; set; }
    [Column("ProductDescription")] public string? Description { get; set; }
    public decimal UnitPrice { get; set; }
    public Guid RowGuid { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }

    public SalesOrderItem? SalesOrderItem { get; set; }
}