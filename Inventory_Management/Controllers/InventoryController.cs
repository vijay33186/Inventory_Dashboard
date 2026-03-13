using Inventory_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Inventory_Management.Controllers
{
    public class InventoryController : Controller
    {
        private readonly InventoryContext _context;

        public InventoryController(InventoryContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchString, string sortOrder, int page = 1)
        {
            var user = HttpContext.Session.GetString("User");

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            int pageSize = 5;

            var items = _context.Inventories.AsQueryable();

            // SEARCH
            if (!string.IsNullOrEmpty(searchString))
            {
                items = items.Where(x => x.Itemname.Contains(searchString));
            }

            // SORT
            switch (sortOrder)
            {
                case "price":
                    items = items.OrderBy(x => x.Price);
                    break;

                case "qty":
                    items = items.OrderBy(x => x.Quantity);
                    break;

                default:
                    items = items.OrderBy(x => x.Id);
                    break;
            }

            // PAGINATION
            int totalItems = items.Count();

            var data = items
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // DASHBOARD DATA
            ViewBag.TotalItems = _context.Inventories.Count();
            ViewBag.TotalQuantity = _context.Inventories.Sum(x => x.Quantity);
            ViewBag.TotalValue = _context.Inventories.Sum(x => x.Price * x.Quantity);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            return View(data);
        }
       
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Inventory item)
        {
            if (ModelState.IsValid)
            {
                _context.Inventories.Add(item);
                _context.SaveChanges();

                TempData["Success"] = "Item added successfully!";
                return RedirectToAction("Index");
            }

            return View(item);
        }
        public IActionResult Edit(int id)
        {
            var item = _context.Inventories.Find(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Inventory item)
        {
            _context.Inventories.Update(item);
            _context.SaveChanges();
            TempData["Success"] = "Item updated successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = _context.Inventories.Find(id);
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = _context.Inventories.Find(id);

            _context.Inventories.Remove(item);
            _context.SaveChanges();
            TempData["Success"] = "Item deleted successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var item = _context.Inventories.Find(id);
            return View(item);
        }
    }
}
