using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDTO> GetCarDetails();
        List<CarDetailDTO> GetCarsByColorId(int colorId);
        List<CarDetailDTO> GetCarsByBrandId(int brandId);
        CarDetailDTO GetCarByCarId(int id);

    }
}
