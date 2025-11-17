using Microsoft.AspNetCore.Mvc;
using CycleStoreStarter.Data;
using CycleStoreStarter.Models;
using System.Text.Json;

namespace CycleStoreStarter.Controllers;
public class CartController : Controller
{
    private readonly AppDbContext _db;
    private const string SessionKey = "cart";
    public CartController(AppDbContext db) => _db = db;

    private List<CartItem> GetCart()
    {
        var s = HttpContext.Session.GetString(SessionKey);
        if (string.IsNullOrEmpty(s)) return new List<CartItem>();
        return JsonSerializer.Deserialize<List<CartItem>>(s) ?? new List<CartItem>();
    }

    private void SaveCart(List<CartItem> cart)
    {
        HttpContext.Session.SetString(SessionKey, JsonSerializer.Serialize(cart));
    }

    public IActionResult Index()
    {
        var cart = GetCart();
        return View(cart);
    }

    [HttpPost]
    public IActionResult Add(int productId, int qty = 1)
    {
        var p = _db.Products.Find(productId);
        if (p == null) return NotFound();
        var cart = GetCart();
        var item = cart.FirstOrDefault(c => c.ProductId == productId);
        if (item == null)
        {
            cart.Add(new CartItem { ProductId = p.Id, ProductName = p.Name, UnitPrice = p.Price, Quantity = qty });
        }
        else
        {
            item.Quantity += qty;
        }
        SaveCart(cart);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Remove(int productId)
    {
        var cart = GetCart();
        cart.RemoveAll(c => c.ProductId == productId);
        SaveCart(cart);
        return RedirectToAction("Index");
    }
}
