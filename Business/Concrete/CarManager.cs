using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void AddCar(Car car)
        {
            if (car.Description.Length <= 2 && car.DailyPrice <=0)
            {
                Console.WriteLine("Araç ekleme başarısız.");
            }
            else
            {
                _carDal.Add(car);
                Console.WriteLine("Araç eklendi");
            }
        }

        public List<Car> GetAll()
        {
            // if(x)
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(p=> p.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(p => p.ColorId == colorId);
        }
    }
}
