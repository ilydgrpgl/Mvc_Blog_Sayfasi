using DataAccessLayer.Concrete;
using Mvc_Proje_Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Proje_Blog.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeResult()
        {
            return Json(Categorylist(), JsonRequestBehavior.AllowGet);
        }
        public List<Class1> Categorylist() 
        {
            List<Class1> c = new List<Class1>();
            c.Add(new Class1()
            {
                CategoryName = "Teknoloji",
                BlogCount=14
            }) ;
            c.Add(new Class1()
            {
                CategoryName = "Spor",
                BlogCount = 10

            });
            c.Add(new Class1()
            {
                CategoryName = "Kitap",
                BlogCount = 16
            });
            return c;
        }
        public ActionResult VisualizeResult2()
        {
            return Json(Bloglist(), JsonRequestBehavior.AllowGet);
        }

        public List<Class2> Bloglist()
        {

            List< Class2> c2 = new List<Class2>();

            using(var c=new Context())
            {
                c2 = c.Blogs.Select(x=>new  Class2
                {
                    BlogName=x.BlogTitle,
                    BlogRating=x.BlogRating
                }).ToList();

            }
            return c2;
        }

        public ActionResult Chart1()
        {
            return View();
        }

        public ActionResult Chart2()
        {
            return View();
        }
        public ActionResult Chart3()
        {
            return View();
        }

    }
}