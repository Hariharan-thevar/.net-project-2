using Microsoft.AspNetCore.Mvc;
using CycleStoreStarter.Data;
using CycleStoreStarter.Models;
using System.Text.Json;

namespace CycleStoreStarter.Controllers;
public class CheckoutController : Controller
{
    private readonly AppDbContext _db;
    private const string SessionKey = "cart";
    public CheckoutController(AppDbContext db) => _db = db;

    private List<CartItem> GetCart()
    {
        var s = HttpContext.Session.GetString(SessionKey);
        if (string.IsNullOrEmpty(s)) return new List<CartItem>();
        return JsonSerializer.Deserialize<List<CartItem>>(s) ?? new List<CartItem>();
    }

    [HttpGet]
    public IActionResult Index()
    {
        var cart = GetCart();
        return View(cart);
    }

    [HttpPost]
    public IActionResult PlaceOrder(string name, string email)
    {
        var cart = GetCart();
        if (!cart.Any()) return RedirectToAction("Index", "Cart");
        var order = new Order { CustomerName = name, Email = email, Total = cart.Sum(c => c.UnitPrice * c.Quantity) };
        _db.Orders.Add(order);
        // reduce stock
        foreach(var item in cart)
        {
            var p = _db.Products.Find(item.ProductId);
            if (p != null) { p.Stock -= item.Quantity; if (p.Stock < 0) p.Stock = 0; }
        }
        _db.SaveChanges();
        HttpContext.Session.Remove(SessionKey);
        return RedirectToAction("Success");
    }

    public IActionResult Success() => View();
}
