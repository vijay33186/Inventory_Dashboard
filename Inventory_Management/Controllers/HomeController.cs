using System.Diagnostics;
using Inventory_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InventoryContext _inventoryContext;
        public HomeController(InventoryContext inventoryContext)
        {
            _inventoryContext = inventoryContext;
        }

        public IActionResult Index()
        {

            var context = _inventoryContext.Users.AsNoTracking().ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
