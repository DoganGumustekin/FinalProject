using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    //bu classı public yaptık(product) ki bu classa diğer katmanlar da ulaşabilsin.
    //dataaccess ürünü ekleyecek, Business Ürünü kontrol edecek, ConsolUI ürünü gösterecek 
    //yani entities i  bu üç katman da kullanacak. erişimi sağlayabilmek için public yapıyorum.
    public class Product:IEntity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; } //stok adedi 
        public decimal UnitPrice { get; set; }
    }
}
