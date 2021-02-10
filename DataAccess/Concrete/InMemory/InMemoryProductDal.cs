using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal //bellekte çalışacak şekilde ıproductı yazacağız. entityframworke geçince ona göre yazacağız.
    {
        List<Product> _products; //global değişken oldugundan böyle isimlendiririz.veritabanı
        public InMemoryProductDal() //bellekte ref aldığı zaaman çalışacak metod 
        {//ürünlerimiz oluşturacağız
            //oracle,sql server,postgres,mongodb sanki ürünlerimiz bu dblerden geliyormuş gibi simüle ediyoruz.başlarken direkt ürünler gelcek.
            _products = new List<Product> {
            new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
            new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
            new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
            new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
            new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ- Language Integrated Query
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId); //id olan uygulamalarda singleordefault genelde bu kullanılır.1 tane getirir. //bu yaptığımız aslında foreach ile aynı mantıkta p takma ismini kendi içinde döndürüp id ye göre getir dedik.
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products; //veritabanını oldugu gibi döndürüyorum.
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //where içindeki sarta uyan bütün elemanları yeni bir liste haline döndürüp getirir.
           return  _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product) //ekrandaki ürün bu tiklayıp gönderiyoruz buraya.
        {
            //gönderdiğim ürün id sine sahip olan listedeki ürünü bul demek.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock; //updateleri gönderdiğim değerle değiştirir.
        }
    }
}
