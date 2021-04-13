using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProducDal : IProductDal
    {
        List<Product> _product;
        public InMemoryProducDal()
        {
            _product = new List<Product> {
           new Product{ CategoryId=1,ProductId=1,ProductName="bardak",UnitsInStock=15,UnitPrice=15 },
           new Product{ CategoryId=2,ProductId=2,ProductName="kamera",UnitsInStock=150,UnitPrice=15 },
           new Product{ CategoryId=3,ProductId=3,ProductName="telefon",UnitsInStock=1500,UnitPrice=15 },
           new Product{ CategoryId=4,ProductId=4,ProductName="klavye",UnitsInStock=150,UnitPrice=15 },
           new Product{ CategoryId=5,ProductId=5,ProductName="fare",UnitsInStock=150,UnitPrice=15 }



            };
          }

        public void Add(Product product)
        {
            _product.Add(product);
        }

        public void Delete(Product product)
        {
            //linq
            //lambda
            //Product productdelete = null;
            //foreach (var p in _product)
            //{
            //    if (product.ProductId==p.ProductId)
            //    {
            //        productdelete = p;
            //    }
            //}
           Product productToDelete = _product.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _product.Remove(productToDelete);

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _product;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
          return  _product.Where(p => p.CategoryId == categoryId).ToList();

        }

        public List<ProductDetailDto> productDetailDtos()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _product.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductId = product.ProductId;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnitPrice = product.UnitPrice;


        }
    }
}
