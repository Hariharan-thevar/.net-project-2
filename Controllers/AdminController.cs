using Microsoft.AspNetCore.Mvc;
using CycleStoreStarter.Data;
using CycleStoreStarter.Models;

namespace CycleStoreStarter.Controllers;
public class AdminController : Controller
{
    private readonly AppDbContext _db;
    public AdminController(AppDbContext db) => _db = db;

    public IActionResult Products()
    {
        var list = _db.Products.ToList();
        return View(list);
    }

    public IActionResult CreateProduct() => View(new Product());

    [HttpPost]
    public IActionResult CreateProduct(Product p)
    {
        if (!ModelState.IsValid) return View(p);
        _db.Products.Add(p);
        _db.SaveChanges();
        return RedirectToAction(nameof(Products));
    }

    public IActionResult EditProduct(int id)
    {
        var p = _db.Products.Find(id);
        if (p == null) return NotFound();
        return View(p);
    }

    [HttpPost]
    public IActionResult EditProduct(Product p)
    {
        _db.Products.Update(p);
        _db.SaveChanges();
        return RedirectToAction(nameof(Products));
    }

    [HttpPost]
    public IActionResult DeleteProduct(int id)
    {
        var p = _db.Products.Find(id);
        if (p != null) { _db.Products.Remove(p); _db.SaveChanges(); }
        return RedirectToAction(nameof(Products));
    }
}
