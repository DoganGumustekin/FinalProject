using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    //concrete classındaki sınıflar bir veritabanı tablosuna denk gelir.
    //artık IEntity Ctegory tablosunun refereansını tutabiliyor.
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
