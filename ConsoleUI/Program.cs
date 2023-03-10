using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
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

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());//categorymanager ı newlemek için ıcategorydal ister.
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
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
