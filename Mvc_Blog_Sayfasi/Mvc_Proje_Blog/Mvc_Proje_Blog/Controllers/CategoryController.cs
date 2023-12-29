using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Proje_Blog.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm =new CategoryManager();// tüm katmanları kullandık
        public ActionResult Index()
        {
            var categoryValues=cm.GetAll();
            return View(categoryValues);
        }
        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            var categoryValues = cm.GetAll();
            return PartialView(categoryValues);
        }
        public ActionResult AdminCategoryList()
        {
            var categorylist=cm.GetAll();
            return View(categorylist);
        }
    }
}