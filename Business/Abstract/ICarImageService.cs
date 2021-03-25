using System;
using System.Collections.Generic;
using System.Text;
using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarImageService:IBaseService<CarImage>
    {
        public IDataResult<List<string>> GetCarImages(int carId);
    }
}
