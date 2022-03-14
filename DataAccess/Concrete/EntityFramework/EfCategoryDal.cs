using Core.DataAcces.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework //microsoft ürünü. linq destekli çalışıyor. URM = veritabanı nesneleri ile bir ilişki kurup 
{                                             //veritabanı işlemlerini yapma süreci.
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal   //entitiy framework .NET içerisinde default olarak bir paket olarak geliyor.NuGet
    {                                           
       
    }
}
