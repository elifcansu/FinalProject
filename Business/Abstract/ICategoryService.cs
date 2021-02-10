﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService //dış dünyaya açıyoruz onun sorguları yazılıyor.
    {
        List<Category> GetAll();
        Category GetById(int categoryId);
    }
}
