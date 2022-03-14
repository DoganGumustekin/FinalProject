using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ProductDetailDto:IDto //buraya IEntity yazamam çünkü bu bir veritabanı tablosu eğil.
    {                                  // birden fazla tablonun bikaç kolonuna karşılık geliyordr.
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }
    }
}
