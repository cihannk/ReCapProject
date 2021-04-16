using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.IM
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars = new List<Car> { new Car { CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 10000, Description = "Ford Focus", ModelYear = 2012 },
         new Car { CarId = 2, BrandId = 1, ColorId = 3, DailyPrice = 20000, Description = "Ford Fiesta", ModelYear = 2010 },
         new Car { CarId = 3, BrandId = 2, ColorId = 2, DailyPrice = 15000, Description = "Toyota Corolla", ModelYear = 2013 },
         new Car { CarId = 4, BrandId = 2, ColorId = 3, DailyPrice = 50000, Description = "Toyota X", ModelYear = 2015 },
         new Car { CarId = 5, BrandId = 3, ColorId = 6, DailyPrice = 300000, Description = "Mercedes Benz", ModelYear = 2019 }};
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
            return _cars.SingleOrDefault(c => c.CarId == id);
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
            int id = car.CarId;
            Car carToUpdate= _cars.SingleOrDefault(c => c.CarId == id);
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDTO> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        List<CarDetailDTO> ICarDal.GetCarsByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        List<CarDetailDTO> ICarDal.GetCarsByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public CarDetailDTO GetCarByCarId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
