using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Contants;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin,car.add,moderator")]
        [CacheRemoveAspect("ICarService.Get")]
        [PerformanceAspect(5)]
        public IResult Add(Car car)
        {         
             _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded); 
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("admin,car.delete,moderator")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect(20)]
        //[SecuredOperation("admin,car.getall,moderator")]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        //[SecuredOperation("admin,car.getbyid,moderator")]
        [CacheAspect(20)]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == id));

        }

        [CacheAspect(20)]
        public IDataResult<CarDetailDTO> GetCarDetailById(int id)
        {
            return new SuccessDataResult<CarDetailDTO>(this._carDal.GetCarByCarId(id));
        }

        //[SecuredOperation("admin,car.getbydetails,moderator")]
        [CacheAspect(20)]
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

        [TransactionScopeAspect]
        [SecuredOperation("admin,car.update,moderator")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult("Araç başarıyla güncellendi");
        }

        public IDataResult<List<CarDetailDTO>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarsByColorId(colorId));
        }
        public IDataResult<List<CarDetailDTO>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarsByBrandId(brandId));
        }
    }
}
