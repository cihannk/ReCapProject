using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length <= 2 && car.DailyPrice <= 0)
            {
                Console.WriteLine("Araç ekleme başarısız.");
            }
            else
            {
                _carDal.Add(car);
                Console.WriteLine("Araç eklendi");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.Get(p => p.Id == id);

        }

        public List<CarDetailDTO> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        //public List<Car> GetCarsByBrandId(int brandId)
        //{
        //    return _carDal.GetAll(p => p.BrandId == brandId);
        //}

        //public List<Car> GetCarsByColorId(int colorId)
        //{
        //    return _carDal.GetAll(p => p.ColorId == colorId);
        //}

        public void Insert(Car car)
        {
            _carDal.Add(car);

        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
