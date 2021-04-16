using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager : ManagerRepository<Brand>, IBrandService
    {
        public BrandManager(IBrandDal brandDal):base(brandDal)
        {
        }

        
    }
}
