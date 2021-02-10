using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //product entitysinin data access deki interface .şuan kullanmasan bile muhakkak oluştur.ilerde kullanabilirsin.
    public interface IProductDal:IEntityRepository<Product> //operasyonları yapacağımız yer. insert add update delete vs.
    {
        List<ProductDetailDto> GetProductDetails();

    }
}


//Code Refactoring