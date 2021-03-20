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
            IRentalDal rentalDal = new EfRentalDal();
            IUserDal userDal = new EfUserDal();
            ICustomerDal customerDal = new EfCustomerDal();


            ICarService carManager = new CarManager(carDal);
            IRentalService rentalManager = new RentalManager(rentalDal);

            //brandDal.Add(new Brand { Id = 2, Description = "wir leiben autos", Name = "Wolksvagen" });
            //colorDal.Add(new Color { Id = 1, Name = "Black" });

            //carManager.AddCar(new Car {Id=6, BrandId=1, ColorId=1, DailyPrice=60000, Description="Passat", ModelYear=2016 });

            // brandDal.Delete(new Brand { Id = 2, Description = "wir leiben autos", Name = "Wolksvagen" });

            //Test(brandDal, colorDal, carDal);

            var details = carManager.GetCarDetails();

            userDal.Add(new User { Id = 1, EMail = "x@gmail.com", FirstName = "Ahmet", LastName = "Sonuç", Password = "ahmet123" });
            customerDal.Add(new Customer { UserId = 1, CompanyName = "ahmet inşaat" });
            rentalManager.Add(new Rental { Id = 1, CarId = 2, CustomerId = 1, RentDate = new DateTime(2021, 3, 20) });
            foreach (var detail in details.Data)
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
