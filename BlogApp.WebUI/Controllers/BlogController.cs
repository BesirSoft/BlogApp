using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogApp.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepostory repostory;
        private ICategoryRepostory categoryrepostory;
        public BlogController(IBlogRepostory _repostory, ICategoryRepostory _categoryrepostory)
        {
            repostory = _repostory;
            categoryrepostory = _categoryrepostory;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {

            return View(repostory.GetAll());
        }


        [HttpGet]
        public IActionResult Create()
        {
          

            var Category = categoryrepostory.GetAll();
            ViewBag.Categoryes = new SelectList(categoryrepostory.GetAll(), "Id", "Name");

           
            return View();
        }

        [HttpPost]
        public IActionResult Create(Blog model)
        {

            model.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                 repostory.AddBlog(model);
                return RedirectToAction("List");
            }
            return View();

            
        }




        [HttpGet]
        public IActionResult Edit(int id)
        {

          
            var Category = repostory.GetByIId(id); 
            ViewBag.Categoryes = new SelectList(categoryrepostory.GetAll(), "Id", "Name");


            return View(Category);
        }

        [HttpPost]
        public IActionResult Edit(Blog model)
        {

           
            if (ModelState.IsValid)
            {

                ViewData["message"] = $"{model.Title} güncellendi";

                repostory.UpdateBlog(model);
                return RedirectToAction("List");
            }
            return View();


        }

        public IActionResult Delete()
        {

            return View();
        }

    }
}