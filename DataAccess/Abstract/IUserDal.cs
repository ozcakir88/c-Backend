using Core.Dataaccess;
using Core.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntitiesRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
