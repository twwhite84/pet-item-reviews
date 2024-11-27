using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetItemReviews.Models;
using System.Linq;

namespace PetItemReviews.Controllers
{
    public class ReviewsController : Controller
    {
        private ItemContext Db {  get; set; }
        public ReviewsController(ItemContext _db)
        {
            Db = _db;
        }

        // BROWSE REVIEWS
        [HttpGet]
        public IActionResult Index([FromQuery(Name ="Name")] string p1, [FromQuery(Name ="Category")] string p2)
        {
            ViewBag.Categories = Db.Categories.OrderBy(c => c.Name).ToList();
            IOrderedQueryable<Item> items = Db.Items.Include(i => i.Category).OrderBy(i => i.Name);
            if (p1 != null) items = (IOrderedQueryable<Item>)items.Where(i => i.Name.Contains(p1.ToLower()));
            if (p2 != null) items = (IOrderedQueryable<Item>)items.Where(i => i.Category.CategoryId == p2);
            return View(items.ToList());
        }

        // ADD REVIEW
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = Db.Categories.OrderBy(c => c.Name);
            return View();
        }

        [HttpPost]
        public IActionResult Add(Item item) {
            if (ModelState.IsValid)
            {
                Db.Add(item);
                Db.SaveChanges();
                return RedirectToAction("Index", "Reviews");
            }
            else
            {
                ViewBag.Categories = Db.Categories.OrderBy(c => c.Name);
                return View(item);
            }
        }
    }
}
