using Microsoft.AspNetCore.Mvc;
using CycleStoreStarter.Data;

namespace CycleStoreStarter.Controllers;
public class HomeController : Controller
{
    private readonly AppDbContext _db;
    public HomeController(AppDbContext db) => _db = db;
    public IActionResult Index()
    {
        var featured = _db.Products.Take(6).ToList();
        return View(featured);
    }
}
