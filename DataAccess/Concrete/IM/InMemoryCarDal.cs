using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.IM
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars = new List<Car> { new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 10000, Description = "Ford Focus", ModelYear = 2012 },
         new Car { Id = 2, BrandId = 1, ColorId = 3, DailyPrice = 20000, Description = "Ford Fiesta", ModelYear = 2010 },
         new Car { Id = 3, BrandId = 2, ColorId = 2, DailyPrice = 15000, Description = "Toyota Corolla", ModelYear = 2013 },
         new Car { Id = 4, BrandId = 2, ColorId = 3, DailyPrice = 50000, Description = "Toyota X", ModelYear = 2015 },
         new Car { Id = 5, BrandId = 3, ColorId = 6, DailyPrice = 300000, Description = "Mercedes Benz", ModelYear = 2019 }};
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(int id)
        {
            Car carToDelete = GetById(id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public List<Car> GetByColor(int colorId)
        {
            return _cars.Where(c => c.ColorId == colorId).ToList();
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            int id = car.Id;
            Car carToUpdate= _cars.SingleOrDefault(c => c.Id == id);
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }

    }
}
