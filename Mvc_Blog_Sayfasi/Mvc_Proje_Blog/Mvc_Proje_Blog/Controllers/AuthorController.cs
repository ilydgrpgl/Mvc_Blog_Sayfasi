using BusinessLayer.Concrete;
using DataAccessLayer.Migrations;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Mvc_Proje_Blog.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager blogmanager = new BlogManager();
        AuthorManager authormanager= new AuthorManager();
        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authordetail=blogmanager.GetBlogByID(id);
            return PartialView(authordetail);
        }
        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogauthorid=blogmanager.GetAll().Where(x=>x.BlogId==id).Select(y=>y.AuthorID).FirstOrDefault();// bloğa ait yazarın ıd sini çekiyoruz.
           
            var authorsblog=blogmanager.GetBlogByAuthor(blogauthorid);// yazarınid ye ihtiyacımız old. için böyle yaptık
            return PartialView(authorsblog);
        }

        public ActionResult AuthorList()
        {
            var authorlists =authormanager.GetAll();
            return View(authorlists);
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor( Author p)
        {
            authormanager.AddAuthorBl(p);
            return RedirectToAction("AuthorList");
        }
        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            Author author = authormanager.FindAuthor(id);
            return View(author);
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author p)
        {
            authormanager.EditAuthor(p);
            return RedirectToAction("AuthorList");
        }
    }
    
}