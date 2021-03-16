using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        public void Add(Car car );
        public void Delete(int id);
        void Update(Car car);
        public List<Car> GetAll();
        public List<Car> GetByColor(int colorId);
        public List<Car> GetByBrandId(int brandId);
        public Car GetById(int id);


    }
}
