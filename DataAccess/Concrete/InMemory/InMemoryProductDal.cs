using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;//elimizde liste var _product ile bu listeye ekleme yaparız

        public InMemoryProductDal()
            {
            _products = new List<Product> { 
            new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitsInStock=15,UnitPrice=15},
            new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitsInStock=3,UnitPrice=500},
            new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitsInStock=2,UnitPrice=1500},
            new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitsInStock=65,UnitPrice=150},
            new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitsInStock=1,UnitPrice=85}
            };

            }
     

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product producttoDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(producttoDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();//categoryidsi eşit olanları yeni tablo yapar
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id sine sahip olan ürünü bul
            Product producttoUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            producttoUpdate.ProductName = product.ProductName;
            producttoUpdate.CategoryId = product.CategoryId;
            producttoUpdate.UnitPrice = product.UnitPrice;
            producttoUpdate.UnitsInStock = product.UnitsInStock;

        }
    }
}
