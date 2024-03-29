﻿using System;
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
        public IActionResult Index(int? id)
        {

            if (id==null)
            {
                return View(repostory.GetAll());
            }
            else
            {
                return View(repostory.GetAll().Where(p=>p.CategoryId==id));
            }
           
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

                TempData["message"] = $"{model.Title} güncellendi";

                repostory.UpdateBlog(model);
                return RedirectToAction("List");
            }
            return View();


        }

        public IActionResult Delete(int id)
        {
            repostory.DleteBlog(id);
            return RedirectToAction("List");
        }




        public IActionResult Details(int id)
        {
            
            return View(repostory.GetByIId(id));
        }




        [HttpGet]




        public IActionResult AddOrUpdate(int? id)
        {
            ViewBag.Categoryes = new SelectList(categoryrepostory.GetAll(), "Id", "Name");
            if (id==null)
            {
              
                return View();
            }
            else
            {
                //not id null olduğu için int dönüşümü saülandı

                var model = repostory.GetByIId((int)id);

                return View(model);
            }

           


            
            

        }
        [HttpPost]

        public IActionResult AddOrUpdate(Blog model)
        {


            if (ModelState.IsValid)
            {
                repostory.SaveBlog(model);
                TempData["message"] = $"{model.Title} güncellendi";
                return RedirectToAction("List");
            }
            else
            {


            }
            ViewBag.Categoryes = new SelectList(categoryrepostory.GetAll(), "Id", "Name");
            return View(model);

        }




    }
}