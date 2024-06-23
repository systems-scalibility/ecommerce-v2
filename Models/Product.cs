using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_v2.Models;

[Table("Product")]
public class Product : Base
{
    [StringLength(100)]
    [Column("ProductName")]
    public string? Name { get; set; }

    [StringLength(100)] public string? CodeNumber { get; set; }

    [Column("ProductDescription")]
    [StringLength(255)]
    public string? Description { get; set; }

    public decimal UnitPrice { get; set; }

    public ICollection<SalesOrderItem>? SalesOrderItems { get; set; }
}