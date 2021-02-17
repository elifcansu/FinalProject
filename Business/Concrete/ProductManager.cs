using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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
        //business codes - iş kodları mesela bir kişiye ehliyet verip vermeme gibi olayları iş kodalrında yaparız
        //validation-doğrulama kodu min karakter sayısı ekranda yazarken altını çizilen olaylar validation.nesnenin yapısı ile ilgili kodlar.
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            _productDal.Add(product);//dala diyor ki ekle
            return new SuccessResult(Messages.ProductAdded); 

        }

        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları
            //yetkisi varmı?
            if (DateTime.Now.Hour == 22) //ürünlerin listesini bu saatte kapatmak istiyoruz.gibi düşün.MaintenanceTime--bakım zamanı 
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed); //yukardaki şartları sağlarsa bana productı getir.
            //_productDal.GetAll() benim datam.
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(p=>p.CategoryId==id)); //gönderdiğim categoryid sine göre filtrele.

        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>( _productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult< List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>( _productDal.GetProductDetails());
        }
    }
}
