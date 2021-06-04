using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory    //5
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;  //class içinde ama method dışında olan değişkenlere global değişken denir. _ ile gösterilir.
        public InMemoryProductDal()
        {
           //Oracle Sql server
            _products = new List<Product> { 
            new Product {ProductId=1,CategoryId=1, ProductName="Bardak",UnitPrice=15, UnıtsInStock=15},
            new Product {ProductId=1,CategoryId=2, ProductName="Kamera",UnitPrice=500, UnıtsInStock=3},
            new Product {ProductId=1,CategoryId=3, ProductName="Telefon",UnitPrice=1500, UnıtsInStock=2},
            new Product {ProductId=1,CategoryId=4, ProductName="Klavye",UnitPrice=150, UnıtsInStock=15},
            new Product {ProductId=1,CategoryId=5, ProductName="Fare",UnitPrice=154, UnıtsInStock=105}
            };
        }
        
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)      //sadece _products.Remove ile silinmez çünkü adres tutucular referanslar aynı değildir.Referenas tip bu şekilde silinmez.
        {
          
            //LİNQ = Launguage Integrated Query , Listedeki verileri sql gibi kullanmamızı sağlar
            // =new product hatalı bir koddur
            

            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId); //LINQ ve bu bir methoddur.
           
            
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
           //Gönderdiğim ürünID'sine sahip olan Listedeki ürün bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnıtsInStock = product.UnıtsInStock;
            

        }

        public List<Product> GetAllByCategory(int categoryID)
        {
           return _products.Where(p => p.CategoryId == categoryID).ToList(); //where içindeki şarta uyan tüm blogları yeni bir liste halinde getirir
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
