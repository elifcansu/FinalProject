using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //entityframworke göre kodlancak.
    //nuget ile entityframworkcore.sql i kurduk data accesse şimdi bu paketin kodlarını kullanabiliriz.
    //IDispossable pattern implementation of C# --using bitince bellekten siliyor garbage collecter sayesinde
    //daha performaslı bir ürün geliştirmiş oluruz.
    //addedentity demek eklenen varlık.git veri kaynağından benim gönderdiğim Producata ekle.
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto {ProductId=p.ProductId,ProductName=p.ProductName,CategoryName=c.CategoryName,UnitsInStock=p.UnitsInStock };
                return result.ToList();
            }
        }
    }
}
