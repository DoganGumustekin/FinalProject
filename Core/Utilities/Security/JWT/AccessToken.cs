using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; } //anahtar değeri
        public DateTime Expiration { get; set; } //o tokenin bitiş süresi
    }
}
