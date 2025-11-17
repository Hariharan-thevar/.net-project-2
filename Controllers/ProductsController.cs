using Microsoft.AspNetCore.Mvc;
using CycleStoreStarter.Data;
using CycleStoreStarter.Models;

namespace CycleStoreStarter.Controllers;
public class ProductsController : Controller
{
    private readonly AppDbContext _db;
    public ProductsController(AppDbContext db) => _db = db;

    public IActionResult Index(string q)
    {
        var products = string.IsNullOrEmpty(q)
            ? _db.Products.ToList()
            : _db.Products.Where(p => p.Name.Contains(q) || p.Description.Contains(q)).ToList();
        return View(products);
    }

    public IActionResult Details(string slug)
    {
        var p = _db.Products.FirstOrDefault(x => x.Slug == slug);
        if (p == null) return NotFound();
        return View(p);
    }
}
