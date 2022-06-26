using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        //ben sana bir key vereyim ona göre datayı getir. 
        T Get<T>(string key); //örneğin productmanagerde liste veya tek bir nesne gibi farklı
                              //farklı veri çekme değişkenleri var o yüzden T diyorum 

        //value=gelecek data bir obje olacak object zaten bütün veri tiplerini temsil ediyordu
        //birde duration var oda verinin cache de nekadar duracağını belirtecek. 
        void Add(string key, object value, int duration);
        object Get(string key);
        bool IsAdd(string key);//bu veriyi veritabanındanmı yoksa cacheden mi
                               //getireceğim bunu yapmak için cachede varsa
                               //cacheden yoksa veritabanından getir.
        void Remove(string key);//sana bir key vereyim onu cacheden uçur. 
        void RemoveByPattern(string pattern); //çinde get olanları yada category olanları uçur.
    }
}
