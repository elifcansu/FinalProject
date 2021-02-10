using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //çıplak class kalmasın
    public class Category:IEntity //ientity categorynin referansını tutar.
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
