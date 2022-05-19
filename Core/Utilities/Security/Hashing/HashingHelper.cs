using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //biz bir password vereceğiz oda dışarıya o iki değeri verecek. 
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) //out dışarıya verilmek istenen değer
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) //hmac = benim cryptografi sınıfında kullanacağım classtır.
            {
                passwordSalt = hmac.Key; //key=ilgili algoritmanın oluşturduğu key değeridir. her kullanıcı için yeni key oluşturur.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //o passwordun byte değerini verdim. 
            }
        }

        //buradaki str password kullanıcının tekrar giriş yapmak için kullandığı parola. 
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) //out yok çükü buraya salt ve hash değerini ben vereceğm.
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //computehash=hesaplanan hash 
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                
            }
            return true;
        }
    }
}
