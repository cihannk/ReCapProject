using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EF
{
    public class EfCarDal : EfEntitiyRepositoryBase<Car, CarDBContext>, ICarDal
    {
        public List<CarDetailDTO> GetCarDetails()
        {
            using (CarDBContext context = new CarDBContext())
            {
                var result = from car in context.Cars join
                             color in context.Colors
                             on car.ColorId equals color.ColorId join
                             brand in context.Brands on car.BrandId equals brand.BrandId
                             select new CarDetailDTO { BrandName= brand.Name, CarName=car.Description, ColorName=color.Name, DailyPrice=car.DailyPrice};
                return result.ToList();        
            }
        }
    }
}
