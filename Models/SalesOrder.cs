using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_v1.Models;

public class SalesOrder
{
    [Column("Id")] public int SalesOrderId { get; set; }
    public string? NumberCode { get; set; }
    public DateTime OrderDate { get; set; }
    public string? Description { get; set; }
    public Guid RowGuid { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }

    public ICollection<SalesOrderItem>? SalesOrderItems { get; set; }
}