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

            //Test(brandDal, colorDal, carDal);

            var details = carDal.GetCarDetails();

            foreach (var detail in details)
            {
                System.Console.WriteLine("Marka:{0}, Model:{1}, Renk:{2}, Price:{3}",detail.BrandName, detail.CarName, detail.ColorName, detail.DailyPrice);

            }

            
        }

        private static void Test(IBrandDal brandDal, IColorDal colorDal, ICarDal carDal)
        {
            brandDal.Add(new Brand { Id = 2, Name = "Audi", Description = "German automobile manufacturer" });
            colorDal.Add(new Color { Id = 2, Name = "Blue" });
            carDal.Add(new Car { Id = 2, BrandId = 2, Description = "A8", ModelYear = 2017, ColorId = 2, DailyPrice = 100000 });
            carDal.Delete(new Car { Id = 6, BrandId = 1, ColorId = 1, DailyPrice = 60000, Description = "Passat", ModelYear = 2016 });
            carDal.Add(new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 60000, Description = "Passat", ModelYear = 2016 });
        }
    }
}
