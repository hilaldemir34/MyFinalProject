using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ProductTest();
            //CategoryTest();
        }

       

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));
            var result = productManager.GetProductDetails();
            if(result.Success==true)
            {
                foreach (var product in result.Data)
            {
                Console.WriteLine(product.ProductName+"/"+product.CategoryName );

            }
            }
            
        }
    } 
}
