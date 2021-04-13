using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using FluentValidation;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcers.Validation;
using Core.Aspect.Autofac.Validation;
using Business.CCS;
using System.Linq;
using Core.Utilities.Business;
using Business.BusinessAspect.AutoFac;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Transaction;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productdal;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productdal = productDal;
            _categoryService = categoryService;
        }
       // [SecuredOperation("product.add,admin")]
       [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]

        public IResult Add(Product product)
        {
            //if (product.ProductName.Length < 2)
            //{
            //    return new ErrorResult(Massages.ProducNameInvalid);
            //}

            // ValidationTool.Validate(new ProductValidator(), product);

         IResult  result=  BusinessRules.Ran(CheckIfProductNameExsist(product.ProductName), 
                CheckIfProductCountCategoryCorrect(product.CategoryId), CheckIfCategoryLimitExcedet());


            if (result!=null)
            {
                return result;
            }
            _productdal.Add(product);
            return new SuccessResult(Massages.ProductAddes);
          
        }
        private IResult CheckIfProductCountCategoryCorrect(int categoryId)
        {
            var result = _productdal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result > 10)
            {
                return new ErrorResult(Massages.ProductCountCategoryError);
            }
            return new SuccessResult(); 
        }
        private IResult CheckIfCategoryLimitExcedet()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count >15)
            {
                return new ErrorResult(Massages.CategoryLimitExcedet);
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductNameExsist(string productName)
        {
            var result = _productdal.GetAll(p => p.ProductName== productName).Any();//any var demek
            if (result)
            {
                return new ErrorResult(Massages.Ayni);
            }
            return new SuccessResult();
        }


        [CacheAspect]

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour==2)
            {
                return new ErrorDataResult<List<Product>>(Massages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productdal.GetAll(),Massages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>( _productdal.GetAll(p => p.CategoryId == id));
        }

        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productdal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnirPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>> (_productdal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> productDetailDtos()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Massages.MaintenanceTime);
            }

            return new SuccessDataResult<List<ProductDetailDto>>(_productdal.productDetailDtos());
        }
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            var result = _productdal.GetAll(p => product.CategoryId == product.CategoryId).Count;
            if (result>=10)
            {
                return new ErrorResult(Massages.ProductCountCategoryError);
            }
            throw new NotImplementedException();
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
