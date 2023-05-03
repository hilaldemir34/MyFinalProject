using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {//business katmanı veri erişime bağımlı bağımlılığımızı minimize ediyoruz _Icategorydal ile
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)//CATEGORYMANAGER olarak veri erişim katmanıın abağımlıyım ama
            //biraz zayıf bağımlılığım var interface üzerinden yani referans üzerinden bağımlıyım o yüzden sen dataaccess katmanında
            //istediğini yapabilirsin kurallara uyarak
        {
            _categoryDal = categoryDal;
        }

        //BAĞIMLILIĞIMI CONSTRUCTOR İLE YAPARIM.

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>( _categoryDal.Get(c => c.CategoryId == categoryId));
        }
    }
}
