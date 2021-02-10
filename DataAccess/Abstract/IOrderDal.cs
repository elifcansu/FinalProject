using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //sql cümlecikleri
    public interface IOrderDal:IEntityRepository<Order>
    {

    }
}
