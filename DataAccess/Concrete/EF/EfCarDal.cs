﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EF
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (CarDBContext context = new CarDBContext())
            {
                var entry= context.Entry(entity);
                entry.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (CarDBContext context = new CarDBContext())
            {
                var entry = context.Entry(entity);
                entry.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (CarDBContext context = new CarDBContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarDBContext context = new CarDBContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
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
