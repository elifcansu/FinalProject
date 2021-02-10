using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //bütün sql operasyonlarımız hazır.
    public class EfOrderDal: EfEntityRepositoryBase<Order, NorthwindContext>,IOrderDal
    {

    }
}
