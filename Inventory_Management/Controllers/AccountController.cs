using ConsoleApp1.Models;
using Inventory_Management.Models;
using Microsoft.AspNetCore.Mvc;
using User = ConsoleApp1.Models.User;

namespace Inventory_Management.Controllers
{
    public class AccountController : Controller
    {

        private readonly InventoryContext _context;


        public AccountController(InventoryContext inventory)
        {
            _context = inventory;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _context.Users
                .FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            if (user != null)
            {
                HttpContext.Session.SetString("User", user.Username);
                return RedirectToAction("Index", "Inventory");
            }

            ViewBag.Message = "Invalid username or password";
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
