using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogApp.WebUI.Models;
using BlogApp.Data.Abstract;

namespace BlogApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IBlogRepostory blogRepository;
        public HomeController(IBlogRepostory _blogRepository)
        {
            blogRepository = _blogRepository;
        }
        public IActionResult Index()
        {
            var bloglar = blogRepository.GetAll();


            return View(bloglar);
        }


        public IActionResult Details()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
