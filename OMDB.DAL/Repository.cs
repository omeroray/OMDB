using OMDB.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OMDB.DAL
{
    public class Repository<T> where T : class
    {
        public List<T> Where(Expression<Func<T, bool>> predicate)
        {
            using (OMDBEntities context = new OMDBEntities())
            {
                return context.Set<T>().Where(predicate).ToList();
            }
        }
        public bool Any(Expression<Func<T, bool>> predicate)
        {
            using (OMDBEntities context = new OMDBEntities())
            {
                return context.Set<T>().Any(predicate);
            }
        }
        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            using (OMDBEntities context = new OMDBEntities())
            {
                return context.Set<T>().FirstOrDefault(predicate);
            }
        }

        //admin crud işlemleri için gereken bölüm

        public T GetById(int id)
        {
            using (OMDBEntities context = new OMDBEntities())
            {
                return context.Set<T>().Find(id);
            }
        }
        public void Add(List<T> items)
        {
            using (OMDBEntities context = new OMDBEntities())
            {
                context.Set<T>().AddRange(items);
                context.SaveChanges();
            }
        }
        public void Add(T item)
        {
            using (OMDBEntities context = new OMDBEntities())
            {
                try
                {
                    context.Set<T>().Add(item);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public void Remove(int id)
        {
            using (OMDBEntities context = new OMDBEntities())
            {
                T item = context.Set<T>().Find(id);
                if (item != null)
                {
                    context.Set<T>().Remove(item);
                    context.SaveChanges();
                }
            }
        }

        public void RemoveRange(Expression<Func<T, bool>> predicate)
        {
            using (OMDBEntities context = new OMDBEntities())
            {
                context.Set<T>().RemoveRange(context.Set<T>().Where(predicate));
                context.SaveChanges();
            }
        }

        public void Update(T item)
        {
            using (OMDBEntities context = new OMDBEntities())
            {
                context.Set<T>().AddOrUpdate(item);
                context.SaveChanges();
            }
        }
    }
}
