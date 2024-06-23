using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_v2.Models;

[Table("SalesOrder")]
public class SalesOrder : Base
{
    [StringLength(100)] public string? CodeNumber { get; set; }
    public DateTime OrderDate { get; set; }

    [Column("OrderDescription")]
    [StringLength(255)]
    public string? Description { get; set; }

    public ICollection<SalesOrderItem>? SalesOrderItems { get; set; }
}