using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebUI.ViewComponentModel
{
    public class CategoriMenuViewComponent: ViewComponent
    {
        private ICategoryRepostory _categoryrepostory;
        public CategoriMenuViewComponent(ICategoryRepostory categoryrepostory)
        {
            _categoryrepostory = categoryrepostory;
        }


        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["id"];
            return View(_categoryrepostory.GetAll());
        }

    }
}
