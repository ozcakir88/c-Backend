using Core.Dataaccess.EntityFremework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFremework
{
    public class EfProductDal : EfEntityRepositoriBase<Product, NortwindContext>, IProductDal
    {
        public List<ProductDetailDto> productDetailDtos()
        {
            using (NortwindContext context=new NortwindContext())
            {
                var result = from p in context.products
                             join c in context.categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto {ProductId=p.ProductId,ProductName=p.ProductName,
                             CategoryName=c.CategoryName,UnitsInStock=p.UnitsInStock};
                return result.ToList();

            }
            
        }
    }
}
