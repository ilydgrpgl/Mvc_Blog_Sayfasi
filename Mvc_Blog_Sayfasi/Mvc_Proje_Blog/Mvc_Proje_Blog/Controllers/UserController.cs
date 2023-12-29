using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvc_Proje_Blog.Controllers
{

    [Authorize]
    public class UserController : Controller
    {
        UserProfileManager _userProfileManager = new UserProfileManager();
        BlogManager bm = new BlogManager();
        public ActionResult Index(string p)
        {

            return View();
        }
        public PartialViewResult Partial1(string p)
        {
            p = (string)Session["Mail"];

            var profilevalues = _userProfileManager.GetAuthorByMail(p);
            return PartialView(profilevalues);
        }
        public ActionResult UpdateUserProfile(Author p)
        {
            _userProfileManager.EditAuthor(p);
            return RedirectToAction("Index");
        }
        public ActionResult BlogList2(string p)
        {
            p = (string)Session["Mail"];
            Context c= new Context();
            int id=c.Authors.Where(x=>x.Mail==p).Select(y=>y.AuthorID).FirstOrDefault();    
            var blogs = _userProfileManager.GetBlogByAuthor(id);
            return View(blogs);
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {

            Blog blog = bm.FindBlog(id);
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;
            List<SelectListItem> values2 = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()
                                            }).ToList();
            ViewBag.values2 = values2;

            return View(blog);// ilk olarak id ye göre blog çekiliyor.


        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {

            bm.UpdateBlog(p);

            return RedirectToAction("BlogList2");


        }
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;
            List<SelectListItem> values2 = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()
                                            }).ToList();
            ViewBag.values2 = values2;
            return View();//ViewBag, Controller ile View arasında veri taşımak için kullanılan bir dinamik nesnedir.
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog b)
        {
            bm.BlogAddBl(b);
            return RedirectToAction("BlogList2");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "Login");
        }



    }
}