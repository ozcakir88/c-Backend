using Core.Dataaccess.EntityFremework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFremework
{
    class EfOrderDal: EfEntityRepositoriBase<Order, NortwindContext>, IOrderDal
    {

    }
}
