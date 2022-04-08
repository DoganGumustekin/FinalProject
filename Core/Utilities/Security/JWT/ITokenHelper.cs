using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
        //test yaparken uyduruk bir token oluşturabilirim. veya bunu başka bir teknikle üretmek isteyebilirim o yüzden createtoken
        //bu helperi oluşturdum.
        //kullanıcı arayüzden adını ve şifresini girdi ve bu bilgileri api ye geldi burada bilgiler doğruysa createtoken operasyonu çalışacak ve ilgili kullanıcı için
        //veritabanına gidecek veri tabanından bu kullanıcının claimlerini buluşturacak ordan birtane json web token üretecek ve onları arayüze verecek.
    }
}
