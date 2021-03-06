﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        //Open Closed Principle--yeni bir prensip ekliyorsak mevcut kodlara dokunma.ef ile biz bunu yaptık. sadece ona ait kodlar yazıldı. mevcut kodlara dokunmadık.
        static void Main(string[] args)
        {
            //DTO -Data Transformation Object
            ProductTest();
            //IoC ile buradaki newlemeyi ortadan kaldırcaz.
            //CategoryTest();

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal())); //bana hangi veri alternatifi ile çalışcağımı söyle

            //foreach (var product in productManager.GetByUnitPrice(50, 100))
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            //Console.WriteLine("------------------\n");

            //foreach (var product in productManager.GetAllByCategoryId(2))
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            //Console.WriteLine("-----------------\n");

            //foreach (var product in productManager.GetAll())
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            //Console.WriteLine("----------------------------\n");

            var result = productManager.GetProductDetails();
            if (result.Success==true) //==true yazmasakta olurdu defaultta öyle
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + " / " + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }
    }
}
