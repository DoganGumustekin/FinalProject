using Core.DataAcces.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal //EfProductdal der ki bütün sana gereken 
    {                                                                                         //bütün operasyonlar EFbase.. de var zaten bende ondan inherit eiliyorum.
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products //ürünlere p de kategorilere c de demek 
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId //p deki categoryid c deki categoryid eşit ise onları join et.
                             select new ProductDetailDto { ProductId = p.ProductId, ProductName = p.ProductName, CategoryName = c.CategoryName, UnitsInStock = p.UnitsInStock };
                return result.ToList();
            }
        }
    }
}
//bu yukarıda IProuctdal(inerit edilen) var onu yazma gereğimiz=product için geçerli mehodalrı IProductdal içerisine yazacağım ve gelip burda inheritli olduğu için
//burada inplement interface diyeceğim ve sadece ıproductdal için geçerli kurallar ıproductdal da olacak.
//category tablosu için yazmam gerken kuralları ıcategorydal interfacesine yazacağım.