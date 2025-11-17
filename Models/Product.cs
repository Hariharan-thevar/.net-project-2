namespace CycleStoreStarter.Models;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Slug { get; set; } = "";
    public string Description { get; set; } = "";
    public decimal Price { get; set; }
    public int Stock { get; set; }
    // Comma separated image filenames in wwwroot/images/
    public string ImageFiles { get; set; } = "";
}
