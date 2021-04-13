using Core.Dataaccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface IProductDal:IEntitiesRepository<Product>
    {
        List<ProductDetailDto> productDetailDtos();
    }
}
