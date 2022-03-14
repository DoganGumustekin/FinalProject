using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();
    }
}
//önemli not: eğer farklı veri erişim tekniklerini kullanma ihtimalim varsa
//Data access te concrete de folderlama (concerte ye yeni klasör ekleme) yapıyoruz.