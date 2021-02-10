using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal; //burada inmemory yada entityframwork görmemeliyiz. ıproductdal ref aldığı somut alternatifleri alır.

        public ProductManager(IProductDal productDal) //erişim alternatifi ver inmemory olabilir enttyframework olabilir.
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //iş kodları
            //yetkisi varmı?
            return _productDal.GetAll(); //yukardaki şartları sağlarsa bana productı getir.
            
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p=>p.CategoryId==id); //gönderdiğim categoryid sine göre filtrele.

        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
