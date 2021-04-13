using Core.Dataaccess.EntityFremework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFremework
{
  public   class EFCategoryDal : EfEntityRepositoriBase<Category, NortwindContext> ,ICatagoryDal
    {
      
    }
}
