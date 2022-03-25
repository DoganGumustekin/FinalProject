using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans
{
    public static class Messages //static demek bu classı sürekli newlemiyim diyorum mesela messages. diyorum.
    {
        public static string ProductAdded = "ürün eklendi";
        public static string ProductNameInvalid = "ürün ismi geçersiz"; //publiclerin isimleri büyük harfle başlamalı. ProductNmaeInvalid gibi
        public static string MaintenanceTime="sistem bakımda";
        public static string ProductListed = "ürünler listelendi";
        public static string ProductCountOfCategoryError = "bu kategoride en fazla 10 adet ürün girebilirsin";
        public static string ProductNameAlreadyExists = "Aynı isimde ürün zaten bulunmakta";
        public static string CategoryLimitExceded = "kategori sayısı 15 ten fazla oluğu için ürün eklenemez. ";
    }
}
