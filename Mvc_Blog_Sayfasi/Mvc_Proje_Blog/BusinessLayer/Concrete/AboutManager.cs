using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager
    {
        Repository<About> repoAbout = new Repository<About>();// generic repository ile ırepository olmadan direkt ulaşıyoruz metoda 

        public List<About> GetAll()
        {
            return repoAbout.List();
        }
       
    }

}
