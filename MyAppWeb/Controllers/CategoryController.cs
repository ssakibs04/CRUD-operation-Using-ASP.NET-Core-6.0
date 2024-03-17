using Microsoft.AspNetCore.Mvc;
using MyApp.DataAccessLayer.Infrasturcture.IRepository;
using MyApp.Models;
using MyAppWeb.DataAccessLayer;


namespace MyAppWeb.Controllers
{
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _unitOfWork.Category.GetAll();

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
            { _unitOfWork.Category.Add(category);
            _unitOfWork.Save();
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
            var category = _unitOfWork.Category.GetT(x=>x.ID==id);
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
            { _unitOfWork.Category.Update(category);
            _unitOfWork.Save();
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
            var category = _unitOfWork.Category.GetT(x => x.ID == id);
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
            var category = _unitOfWork.Category.GetT(x => x.ID == id);
                if(category == null)
            {
                return NotFound();
            

            }
                _unitOfWork.Category.Delete(category);
            _unitOfWork.Save();
            TempData["Success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
           
        }
    }
}
