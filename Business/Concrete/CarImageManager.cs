using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Contants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public IResult Add(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckNumberOfPhoto(carImage));
            if (result != null)
            {
                return result;
            }
            string path = @"C:\Users\Cihan\source\repos\ReCapProject\Entities\EntityAssets\CarImage\";
            carImage.ImagePath = path + (string)carImage.ImagePath;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage rental)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());

        }

        public IDataResult<CarImage> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(CarImage rental)
        {
            throw new NotImplementedException();
        }

        public IResult CheckNumberOfPhoto(CarImage carImage)
        {
            List<CarImage> results = _carImageDal.GetAll(car => car.CarId == carImage.CarId);
            if (results.Count >= 5)
            {
                return new ErrorResult(Messages.CarImageExceeded);
            }
            return new SuccessResult();
        }

        public IResult CheckAnyImageOfCarsById(int carId)
        {
            var carImages = _carImageDal.GetAll(car => car.CarId == carId).Any();
            if (carImages)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<string>> GetCarImages(int carId)
        {
            var result = BusinessRules.Run(CheckAnyImageOfCarsById(carId));

            if (result != null)
            {
                return new ErrorDataResult<List<string>>(result.Message);
            }

            List<string> carLinks = new List<string>();
            var results = _carImageDal.GetAll(car => car.CarId == carId);
            foreach (var resul in results)
            {
                if (resul.ImagePath != null) carLinks.Add(resul.ImagePath);
                else carLinks.Add("default");
            }
            return new SuccessDataResult<List<string>>(carLinks);
        }
    }
}
