using BusinessLayer.Concrete;
using DataAccessLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Proje_Blog.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        // GET: About
        AuthorManager autman = new AuthorManager();

        AboutManager abm =new AboutManager();
        public ActionResult Index()
        {
            var aboutcontent = abm.GetAll();

            return View(aboutcontent);
        }
        public PartialViewResult Footer()// öne çıkan postlar 
        {
           var aboutcontentlist= abm.GetAll();
            
            return PartialView(aboutcontentlist);
        }
        public PartialViewResult MeetTheTeam()
        {
           
            var authorlist=autman.GetAll();
            return PartialView(authorlist);
        }

       



    }
}