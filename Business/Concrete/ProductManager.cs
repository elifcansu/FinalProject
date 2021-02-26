using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal; //burada inmemory yada entityframwork görmemeliyiz. ıproductdal ref aldığı somut alternatifleri alır.

        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal,ICategoryService categoryService) //erişim alternatifi ver inmemory olabilir enttyframework olabilir.
        {
            _productDal = productDal;
            _categoryService = categoryService;
            

        }
        //business codes - iş kodları mesela bir kişiye ehliyet verip vermeme gibi olayları iş kodalrında yaparız
        //validation-doğrulama kodu min karakter sayısı ekranda yazarken altını çizilen olaylar validation.nesnenin yapısı ile ilgili kodlar.


        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //bir kategoride en fazla 10 ürün olabilir.
            //aynı isimde ürün eklenemez.
            //eğer mevcut kategori sayısı 15 i geçtiyse sisteme yeni ürün eklenemez
            
           IResult result= BusinessRules.Run(CheckIfProductNameExists(product.ProductName), CheckIfProductCountOfCategoryCorrect(product.CategoryId),CheckIfCategoryLimitExceded());

            if(result!=null) //result kurala uymayan demek
            {
                return result;
            }

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

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed); //yukardaki şartları sağlarsa bana productı getir.
            //_productDal.GetAll() benim datam.
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id)); //gönderdiğim categoryid sine göre filtrele.

        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            //select count(*) from products where categoryId=1 arka tarafta bu query çalışır aslında
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
