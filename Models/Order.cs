namespace CycleStoreStarter.Models;
public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = "";
    public string Email { get; set; } = "";
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public decimal Total { get; set; }
}
