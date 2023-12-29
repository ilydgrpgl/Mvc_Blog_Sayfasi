using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorManager
    {
        Repository<Author> repoAuthor = new Repository<Author>();

        //Tüm Yazar Listesini Getirme
        public List<Author> GetAll()
        {
            return repoAuthor.List();
        }
        //Yeni Yazar ekleme işlemi
        public int AddAuthorBl(Author author)
        {
            //Parametreden gönderilen değerlerin geçerliliğinin kontrolü
            if(author.AuthorName==""|author.AboutShort==""|author.AuthorTitle=="")
            {
                return -1;
            }
            return repoAuthor.Insert(author);
        }
        //Yazarın ıd değerine göre edit sayfasına taşıma
        public Author FindAuthor(int getid)
        {
            return repoAuthor.Find(x => x.AuthorID == getid);// ilk Bloglar çekiliyor.
        }
        public int EditAuthor(Author p)
        {
                Author author=repoAuthor.Find(x=>x.AuthorID == p.AuthorID);
                author.AboutShort=p.AuthorAbout;
                author.AuthorName=p.AuthorName;
                author.AuthorImage=p.AuthorImage;
                 author.AuthorAbout = p.AuthorAbout;
                author.AuthorTitle=p.AuthorTitle;
                author.Mail=p.Mail;
                author.Password=p.Password;
                author.PhoneNumber=p.PhoneNumber;
               return repoAuthor.Update(author);
               
        }
    }
    
}
