using System;
using System.Collections.Generic;
using System.Text;
using Core.Dataaccess;
using Entities.Concrete;
namespace DataAccess.Abstract
{
  public  interface ICustomerDal:IEntitiesRepository<Customer>
    {

    }
}
