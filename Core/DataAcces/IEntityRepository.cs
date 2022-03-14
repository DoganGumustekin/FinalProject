using Core.Entities;
using System;
using System.Collections.Generic;                           //generic(kısıtlama) constraint
using System.Linq;                                          //class : bana referans tip göndereceksin (product, category, customer)
using System.Linq.Expressions;                              //böyle yaparsak IEntity de parametre olarak verebiliriz bunu engellememiz için new() komutu atamalıyız.
using System.Text;                                          //ki sadece newlenebilir bir class olmalı IEntity bir interface dir ve newlenemez
using System.Threading.Tasks;                   

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter = null); //filtre optimizasyonu filter=null filtre vermeyedebilirsin de demek
        T Get(Expression<Func<T, bool>> filter);//diyelim ki banka hesaplarım var ve ben bir tane banka hesabıma bastığımda onun ayrıntılarını görmek istiyorum bu işe yarıyor. burda en az 1 filre olmalı o yüzen null değil.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
