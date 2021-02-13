using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: Db tabloları ile proje classlarını bağlamak,DbContext kurduğumuz nuget dan geldi. 
    public class NorthwindContext:DbContext
    {
        //OnConfiguring: bu metod senin projen hangi veri tabanı ile ilişkili oldugunu belirttiğimiz yer.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true"); //sql servera bağlanmayı gösteriyoruz.
        }//context burada hangi veritabanına bağlandığını buldu.

        //aşağıdaki nesnelerimize karşılık gelen veritabanındaki tablolara bağladık
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }


    }
}
