using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken //kullanıcı istek zarfını, kullanıcı yetkisi varsa tokeni de zarfa koyar ve gönderir buna accestoken denir
    {
        public string Token { get; set; } //anahtar değeri
        public DateTime Expiration { get; set; } //o tokenin bitiş süresi
    }
}
