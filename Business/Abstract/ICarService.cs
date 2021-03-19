using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetById(int id);
        void Insert(Car car);
        void Update(Car car);
        void Add(Car car);
        void Delete(Car car);
        List<CarDetailDTO> GetCarDetails();
    }
}
