using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager:ManagerRepository<Customer>, ICustomerService
    {
        public CustomerManager(ICustomerDal customerDal):base(customerDal)
        {

        }
    }
}
