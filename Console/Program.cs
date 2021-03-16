using System;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.IM;
using Entities.Concrete;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarDal carDal = new InMemoryCarDal();
            carDal.Add(new Car { Id = 6, BrandId = 3, ColorId = 2, DailyPrice = 6000, Description = "Toyota Mordor", ModelYear = 1999 });
            ICarService carManager = new CarManager(carDal);
            var cars = carManager.GetAll();
            foreach (var item in cars)
            {
                System.Console.WriteLine(item.Description);
            }
            carDal.Delete(6);
            foreach (var item in cars)
            {
                System.Console.WriteLine(item.Description);
            }
        }
    }
}
