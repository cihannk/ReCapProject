﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService:IBaseService<Car>
    {
        IDataResult<List<CarDetailDTO>> GetCarDetails();
        IDataResult<List<CarDetailDTO>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailDTO>> GetCarsByBrandId(int brandId);
        IDataResult<CarDetailDTO> GetCarDetailById(int id);
    }
}
