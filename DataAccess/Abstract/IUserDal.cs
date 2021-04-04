using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        public List<OperationClaim> GetClaims(User user);
    }
}
