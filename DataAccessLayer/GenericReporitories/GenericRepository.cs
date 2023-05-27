using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.GenericReporitories
{
    public class GenericRepository <T>: IGenericDal<T> where T : class
    {
        public void Add(T t)
        {
            using var Context = new Context();
            Context.Add(t);
            Context.SaveChanges();
        }

        public void Delete(T t)
        {
            using var Context = new Context();
            Context.Remove(t);
            Context.SaveChanges();
        }

        public T GetById(int id)
        {
            using var Context = new Context();
            return Context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            using var Context = new Context();
            return Context.Set<T>().ToList();
        }

      

        public void Update(T t)
        {
            using var Context = new Context();
            Context.Update(t);
            Context.SaveChanges();
        }
    }
}
