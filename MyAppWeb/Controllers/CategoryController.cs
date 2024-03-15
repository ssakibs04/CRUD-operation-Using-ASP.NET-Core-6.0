using Microsoft.AspNetCore.Mvc;
using MyAppWeb.Data;
using MyAppWeb.Models;

namespace MyAppWeb.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDBContext _context;

        public CategoryController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _context.categories;

            return View(categories);
        }

        //Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            { _context.categories.Add(category);
            _context.SaveChanges();
                TempData["Success"] = "Category Created Successfully";
            return RedirectToAction("Index");

            }
            return View(category);
           
        }
        //Edit
        
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var category = _context.categories.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if(ModelState.IsValid)
            { _context.categories.Update(category);
            _context.SaveChanges();
                TempData["Success"] = "Category Edited Successfully";
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
           
        }
        //Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var category = _context.categories.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int?id)
        {
            var category = _context.categories.Find(id);
                if(category == null)
            {
                return NotFound();
            

            }
                _context.categories.Remove(category);
            _context.SaveChanges();
            TempData["Success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
           
        }
    }
}
