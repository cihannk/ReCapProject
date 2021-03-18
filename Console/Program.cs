using System;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.IM;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using System.Linq;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IBrandDal brandDal = new EfBrandDal();
            IColorDal colorDal = new EfColorDal();
            ICarDal carDal = new EfCarDal();

            ICarService carManager = new CarManager(carDal);

            //brandDal.Add(new Brand { Id = 2, Description = "wir leiben autos", Name = "Wolksvagen" });
            //colorDal.Add(new Color { Id = 1, Name = "Black" });

            //carManager.AddCar(new Car {Id=6, BrandId=1, ColorId=1, DailyPrice=60000, Description="Passat", ModelYear=2016 });

            // brandDal.Delete(new Brand { Id = 2, Description = "wir leiben autos", Name = "Wolksvagen" });

            var cars = carManager.GetAll();
            var brands = brandDal.GetAll();
            var colors = colorDal.GetAll();

            foreach (var item in cars)
            {
                System.Console.WriteLine("Id:{0} Name:{1} Description: {2} Price: {3} Color: {4}",item.Id, brands.SingleOrDefault(p => p.Id == item.BrandId).Name, item.Description, item.DailyPrice, colors.SingleOrDefault(p => p.Id == item.ColorId).Name  );
            }
        }
    }
}
