using Business.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService 
    {
        InMemoryProductDal _productDal;  //Injection yaparız çünkü bir iş sınıfı başka bir iş sınıfını newlemez
        private EfProductDal efProductDal;
        private object return_productDal;

        public ProductManager(InMemoryProductDal productDal)     //ınmemory
        {
            _productDal = productDal;
        }

        public ProductManager(EfProductDal efProductDal) //framework
        {
            this.efProductDal = efProductDal;
        }

        public List<Product> GetAll()
        {
            //iş kodları(if else) yetkisi varsa vs
            return _productDal.GetAll(); //ifi geçerse listeyi ver
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max); //minden büyük maxdan küçük
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
