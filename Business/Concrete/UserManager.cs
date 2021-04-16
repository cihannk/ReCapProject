using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Business.Concrete;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserManager : ManagerRepository<User>, IUserService
    {
        public UserManager(IUserDal userDal) : base(userDal)
        {
            
        }

        public User GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(base._dal.Get(user => user.UserId == id));
        }

        public List<OperationClaim> GetClaims(User user)
        {
            throw new NotImplementedException();
        }

        void IUserService.Add(User user)
        {
            throw new NotImplementedException();
        }
    }
}
