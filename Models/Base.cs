namespace ecommerce_v2.Models;

public class Base
{
    public int Id { get; set; }
    public Guid RowGuid { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
}