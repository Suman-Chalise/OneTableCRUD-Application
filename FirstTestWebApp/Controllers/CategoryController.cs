using FirstTestWebApp.Data;
using FirstTestWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics.CodeAnalysis;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FirstTestWebApp.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)  // creating contructor and creating implementations of connections stinrg and Ddatbase
        {
            _context = context; 
        }


        public IActionResult Index()
        {

            // var objCategoryList = _context.C_Categories.ToList();  // this or below both works

            IEnumerable<Categories> objCategoryList = _context.C_Categories;

            return View(objCategoryList);
        }


        //Get method below for create

		public IActionResult Create()
		{
			return View();
		}


        // Post method below for create
        [HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult Create(Categories cate)
		{

            // for validation 

            if (cate.CategoryName == cate.DisplayOrder.ToString())
            {
				//ModelState.AddModelError("CustomError", "The Display Order can not exactly match the Name!");
				ModelState.AddModelError("CategoryName", "The Display Order can not exactly match the Name!");
			}
          

            if (ModelState.IsValid)
            {
				_context.C_Categories.Add(cate);
				_context.SaveChanges();

                TempData["CreatedSuccess"] = "Category Created Succesfully";  // alert for action 

				//return View();
				return RedirectToAction("Index");

			}
            return View(cate);
  
		}

        public IActionResult Edit(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var dd = _context.C_Categories.Find(id);

             //  var categoryfromFirst = _context.C_Categories.FirstOrDefault(a=>a.CategoryId == id);
			//var categoryfromSingle = _context.C_Categories.SingleOrDefault(a => a.CategoryId == id);

            if (dd == null)
            {
                return NotFound(dd);

            }
			return View(dd);
        }

        //post for edit 

        [HttpPost]
        public IActionResult Edit(Categories cta)
		{

			// for validation 

			if (cta.CategoryName == cta.DisplayOrder.ToString())
			{
				//ModelState.AddModelError("CustomError", "The Display Order can not exactly match the Name!");
				ModelState.AddModelError("CategoryName", "The Display Order can not exactly match the Name!");
			}


			if (ModelState.IsValid)
            {
                _context.C_Categories.Update(cta);
                _context.SaveChanges();
				TempData["EditedSuccess"] = "Category Edited Succesfully";  // alert for action 
				return RedirectToAction("Index");

            }
            return View(cta);
        }


        //Get 
        [HttpGet]
        public IActionResult Delete (int id)
        {
           var da =  _context.C_Categories.Find(id);

            if (da == null)
            {
                return NotFound();

            }
            return View(da);

        }

        //Post

        //[HttpPost]
        [HttpPost, ActionName("Delete")] // this is because on our delete page we have specify asp-action DeletePost if we want to keep asp-action=Delete then we can use this httppost
        public IActionResult DeletePost(int id)
        {
            var da = _context.C_Categories.Find(id);

            if (da == null)
            {
                return NotFound();
            }

            _context.C_Categories.Remove(da);
            _context.SaveChanges();
			TempData["DeletedSuccess"] = "Category Deleted Succesfully";  // alert for action 
			return RedirectToAction("Index");
        }




    }
}
