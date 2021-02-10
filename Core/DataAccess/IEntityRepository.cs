using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //generic constraint ---generic kısıt. T ye kısıt getiriyoruz T sadece entityler olsun product category vs.
    //class:referans tip olabilir demek.
    //IEntity:IEntity olabilir veya IEntity i implemente eden bir nesne olabilir.
    //new():new'lenebilir olmalı. bu sayede IEntity i devre dışı bıraktık onu koyamayız çünkü o newlenemez.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //veri tabanındaki verilerin tamamını listelemek için kullanırız.expresssion çağırdığımız ürünle ilgili filtreleme yapmamızı sağlar.mesela id si 2 olanları getir yazabiliriz.filtre vermediyse hepsi döner.
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
