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
        internal static string MaintenanceTime="sistem bakımda";
        internal static string ProductListed = "ürünler listelendi";
    }
}
