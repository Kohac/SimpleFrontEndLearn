using Microsoft.AspNetCore.Mvc;
using SimpleFrontEndLearn.Context;
using SimpleFrontEndLearn.Models;

namespace SimpleFrontEndLearn.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> result = _context.Categories;
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                TempData["success"] = "Category Created sucesfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult Edit(int? id)
        {
            if (id is null || id == 0) return NotFound();
            var result = _context.Categories.Find(id);
            //var resultFirst = _context.Categories.FirstOrDefault(x => x.Id == id);
            //var resultSingle = _context.Categories.SingleOrDefault(x => x.Id == id);
            if (result is null) return NotFound();

            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                TempData["success"] = "Category Updated sucesfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0) return NotFound();
            var result = _context.Categories.Find(id);
            //var resultFirst = _context.Categories.FirstOrDefault(x => x.Id == id);
            //var resultSingle = _context.Categories.SingleOrDefault(x => x.Id == id);
            if (result is null) return NotFound();

            return View(result);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var result = _context.Categories.Find(id);
            if (result == null) return NotFound();
            _context.Categories.Remove(result);
            _context.SaveChanges();
            TempData["success"] = "Category Deleted sucesfully";
            return RedirectToAction("Index");
        }
    }
}
