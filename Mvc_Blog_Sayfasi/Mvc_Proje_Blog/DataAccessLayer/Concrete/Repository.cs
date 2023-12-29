using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        Context c=new Context();//Entity Framework aracılığıyla veritabanı ile iletişim kurmak için kullanılır.
        DbSet<T> _object;//veri erişim işlemlerini gerçekleştirmek için kullanılır

        public Repository()//Repository sınıfı, veri erişim işlemlerini gerçekleştirmek için Context ve DbSet'i kullanabilir.
        {
            _object=c.Set<T>();
        }// veriyi işliyoruz ve bunu mevcut veritabanına gönderiyoruz
        public int Delete(T p)
        {
            _object.Remove(p);
            return c.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _object.FirstOrDefault(where);
        }

        public T GetById(int id)
        {
            return _object.Find(id);
        }

        public int Insert(T p)
        {
            _object.Add(p);
            return c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return _object.Where(where).ToList();
        }

        public int Update(T p)
        {
            
            return c.SaveChanges();
        }
    }
}
