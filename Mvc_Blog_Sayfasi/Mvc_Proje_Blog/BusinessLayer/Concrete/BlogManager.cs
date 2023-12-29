using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager
    {
        Repository<Blog> repoBlog = new Repository<Blog>();// generic repository ile ırepository olmadan direkt ulaşıyoruz metoda 

        public List<Blog> GetAll()
        {
            return repoBlog.List();
        }

        public List<Blog> GetBlogByID(int id)
        {
            return repoBlog.List(x=>x.BlogId== id);
        }
        public List<Blog> GetBlogByAuthor(int id)
        {
            return repoBlog.List(x => x.AuthorID == id);
        }
        public List<Blog> GetBlogByCategory(int id)
        {
            return repoBlog.List(x => x.CategoryID == id);
        }
        public int BlogAddBl(Blog p)
        {
            if(p.BlogTitle=="" || p.BlogImage==""|| p.BlogTitle.Length<=5||p.BlogContent.Length<=200)
            {
                return -1;
            }
            return repoBlog.Insert(p);
        }
        public int DeleteBlogBl(int p)
        {
            Blog blog=repoBlog.Find(x=>x.BlogId==p);
            return repoBlog.Delete(blog);
        }
        public Blog FindBlog(int getid)
        {
            return repoBlog.Find(x=>x.BlogId== getid);// ilk Bloglar çekiliyor.
        }
        public int UpdateBlog(Blog p)
        {
            Blog blog = repoBlog.Find(x => x.BlogId == p.BlogId);
            blog.BlogTitle = p.BlogTitle;
            blog.BlogImage = p.BlogImage;
            blog.BlogContent = p.BlogContent;
            blog.CategoryID = p.CategoryID;
            blog.AuthorID = p.AuthorID;
            return repoBlog.Update(blog);
                

            
        }

    }
}
