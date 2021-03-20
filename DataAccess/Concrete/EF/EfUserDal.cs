using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EF
{
    public class EfUserDal:EfEntitiyRepositoryBase<User, CarDBContext>, IUserDal
    {
    }
}
