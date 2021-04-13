using Business.Concrete;
using DataAccess.Concrete.EntityFremework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // CatagoryTest();

            ProductTest();

        }

        private static void CatagoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            foreach (var catagory in categoryManager.GetAll().Data)
            {
                Console.WriteLine(catagory.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EFCategoryDal()));
            var Result = productManager.productDetailDtos();
            if (Result.Success==true)
            {
                foreach (var product in Result.Data)
                {
                    Console.WriteLine(product.ProductName + " /" + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(Result.Message);
            }
            
        }
    }
}
