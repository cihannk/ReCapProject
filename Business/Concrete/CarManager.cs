﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Contants;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length <= 2 && car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.NotEnoughInfo);
            }
            
             _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

            
            
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id));

        }

        public IDataResult<List<CarDetailDTO>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetails());
        }

        //public List<Car> GetCarsByBrandId(int brandId)
        //{
        //    return _carDal.GetAll(p => p.BrandId == brandId);
        //}

        //public List<Car> GetCarsByColorId(int colorId)
        //{
        //    return _carDal.GetAll(p => p.ColorId == colorId);
        //}

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult("Araç başarıyla güncellendi");
        }
    }
}
