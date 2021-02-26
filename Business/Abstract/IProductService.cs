using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        //iş katmanında kullanacığımız servisler
        IDataResult<List<Product>> GetAll(); //ürün listesi döndürürüyor. T list<product> ıdataresult bana mesaj ve sonuc döndrür demek istiyoruz.
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);

        IDataResult<List<ProductDetailDto>> GetProductDetails();

        IDataResult<Product> GetById(int productId); //bunu gerçek haytatta ürün detayına girmek istediğimizde kullanılıyoruz genelde
        IResult Add(Product product); //void yerine ıresult dicem artık

        IResult Update(Product product);
        //restful---->http ---> 
    }
}
