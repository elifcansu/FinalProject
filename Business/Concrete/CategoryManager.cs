using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal; //dataaccese olan bağımlılık milimize edilir.

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal; //interface üzerinden bağımlıyım  diyor.
        }

        public List<Category> GetAll()
        {
            //iş kodları
            return _categoryDal.GetAll();
        }

        //select * from categories where categoryId=3 gibi bir kod yazılı aslında
        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }
    }
}
