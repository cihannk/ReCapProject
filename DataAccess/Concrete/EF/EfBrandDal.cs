using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EF
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (CarDBContext context = new CarDBContext())
            {
                var entry = context.Entry(entity);
                entry.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (CarDBContext context = new CarDBContext())
            {
                var entry = context.Entry(entity);
                entry.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (CarDBContext context = new CarDBContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (CarDBContext context = new CarDBContext())
            {
                return filter == null ? context.Set<Brand>().ToList() : context.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand entity)
        {
            using (CarDBContext context = new CarDBContext())
            {
                var entry = context.Entry(entity);
                entry.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
