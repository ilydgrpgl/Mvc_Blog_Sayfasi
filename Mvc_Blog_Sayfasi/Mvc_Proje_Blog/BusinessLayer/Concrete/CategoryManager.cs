using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        Repository<Category> repoCategory=new Repository<Category>();// generic repository ile ırepository olmadan direkt ulaşıyoruz metoda 
        public List<Category>GetAll()
        {
            return repoCategory.List();
        }
    }
}
