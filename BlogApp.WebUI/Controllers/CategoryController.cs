using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepostory repsitry;
        public CategoryController(ICategoryRepostory _repsitry)
        {
            repsitry = _repsitry;

        }
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Category model)
        {

            repsitry.AddCategory(model);
            return View();
        }
    }
}