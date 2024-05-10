using CRUDTest.Data;
using CRUDTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDTest.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> CategoryList = _db.Categories;
            return View(CategoryList);
        }

        //Get دادن اطلاعات برای نمایش
        //create view fro this action for give data from user
        public IActionResult Create()
        {
            return View();
        }

        //create post action for recive and save data in db 
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //create custom error message 
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Custom Error", "مقدار فیلد ترتیب نمایش نباید با مقدار فیلد نام یکسان باشد");
            }
            //check for model data is correct
           if(ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
           return View();
        }
    }
}
