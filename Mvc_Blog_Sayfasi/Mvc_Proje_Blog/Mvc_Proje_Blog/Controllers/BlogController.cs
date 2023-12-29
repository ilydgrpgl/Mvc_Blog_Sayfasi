using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Mvc_Proje_Blog.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        BlogManager bm = new BlogManager();
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogList(int page =1)// blog kıımlarının listelenmesi 
        {
            var bloglist = bm.GetAll().ToPagedList(page,6);
            return PartialView(bloglist);
        }
        [AllowAnonymous]
        public PartialViewResult FeaturedPost()// öne çıkan postlar 
        {
            //1.post
            var postTitle1=bm.GetAll().OrderByDescending(z => z.BlogId).Where(x=>x.CategoryID==1).Select(y =>y.BlogTitle).FirstOrDefault();
            var postImage1= bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 1).Select(y => y.BlogImage).FirstOrDefault();
            var blogpostid1= bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 1).Select(y => y.BlogId).FirstOrDefault();


            ViewBag.PostTitle1=postTitle1;
            ViewBag.postImage1 = postImage1;
            ViewBag.blogpostid1 = blogpostid1;

             // css ve div değerleri farklı olduğu için ayrı ayrı yazılıyor.
           //2.post
            var postTitle2 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 2).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage2 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 2).Select(y => y.BlogImage).FirstOrDefault();
            var blogpostid2 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 1).Select(y => y.BlogId).FirstOrDefault();



            ViewBag.PostTitle2 = postTitle2;
            ViewBag.postImage2 = postImage2;
            ViewBag.blogpostid2 = blogpostid2;
            
            //3.post
            var postTitle3 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 6).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage3 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 6).Select(y => y.BlogImage).FirstOrDefault();
            var blogpostid3 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 1).Select(y => y.BlogId).FirstOrDefault();



            ViewBag.PostTitle3 = postTitle3;
            ViewBag.postImage3 = postImage3;
            ViewBag.blogpostid3 = blogpostid3;

            //4.post
            var postTitle4 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 4).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage4 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 4).Select(y => y.BlogImage).FirstOrDefault();
            var blogpostid4 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 1).Select(y => y.BlogId).FirstOrDefault();



            ViewBag.PostTitle4 = postTitle4;
            ViewBag.postImage4 = postImage4;
            ViewBag.blogpostid4 = blogpostid4;

            //5.post
            var postTitle5 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 7).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage5 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 7).Select(y => y.BlogImage).FirstOrDefault();
            var blogpostid5 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 1).Select(y => y.BlogId).FirstOrDefault();



            ViewBag.PostTitle5 = postTitle5;
            ViewBag.postImage5 = postImage5;
            ViewBag.blogpostid5 = blogpostid5;

            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult OtherFeaturedPost()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public ActionResult BlogDetails()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id);
            return PartialView(BlogDetailsList);
        }
        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id);
            return PartialView(BlogDetailsList);
        }
        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var BloglistByCategory=bm.GetBlogByCategory(id);
            var CategoryName=bm.GetBlogByCategory(id).Select(y=>y.Category.CategoryName).FirstOrDefault();
            ViewBag.CategoryName = CategoryName;
            var CategoryDesc = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryDescription).FirstOrDefault();
            ViewBag.CategoryDesc = CategoryDesc;
            return View(BloglistByCategory);
        }
        public ActionResult BlogListAdmin()
        {
            var bloglist = bm.GetAll();
            return View(bloglist);
        }
        public ActionResult BlogListAdmin2()
        {
            var bloglist = bm.GetAll();
            return View(bloglist);
        }


        [Authorize(Roles="A")]
        [HttpGet]
        public ActionResult AddNewBlog()
        {
           Context c= new Context();
            List<SelectListItem> values=(from x in c.Categories.ToList()
                                         select new SelectListItem
                                         {
                                          Text=x.CategoryName,
                    Value=x.CategoryID.ToString()
                                          }).ToList();
            ViewBag.values=values;
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
            return RedirectToAction("BlogListAdmin");
        }
        public ActionResult DeleteBlog(int id)
        { 
            bm.DeleteBlogBl(id);
            return RedirectToAction("BlogListAdmin");
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            
            Blog blog =bm.FindBlog(id);
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

            return RedirectToAction("BlogListAdmin");


        }
        public ActionResult GetCommentByBlog(int id)
        {
            CommentManager cm = new CommentManager();
            var CommentList = cm.CommentByBlog(id);
            return View(CommentList);
        }
        public ActionResult AuthorBlogList(int id)
        {
           
            var blogs = bm.GetBlogByAuthor(id);
            return View(blogs);
        }

    }
}