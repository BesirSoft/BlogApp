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

            repostory.AddBlog(model);

            return RedirectToAction("List");
        }

        public IActionResult Delete()
        {

            return View();
        }

    }
}