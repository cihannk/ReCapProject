using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IResult Update(Car car);
        IResult Add(Car car);
        IResult Delete(Car car);
        IDataResult<List<CarDetailDTO>> GetCarDetails();
    }
}
