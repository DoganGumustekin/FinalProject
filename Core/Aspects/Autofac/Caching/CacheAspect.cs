using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            //invocation.Method.ReflectedType.FullName burası bana namespace + class ismini verir geiye kalan kısım ise method ismini verir
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();//methodun parmaetrelerini bir listeye al 
            //bu parametreler benim keyimdir. Parametreleri de namespaceden sonra gelen method isminin parametresine içine ekle
            //bu parametresiz bir method da olabilir o yüzden null değerini de kontrol ediyorum burada keyi oluşturduk.
            //string.join ile onları , ile yanyana getir.
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";//parametreli yerlerini listeye çevir.
                                                                                                            //getall(1,2) gibi.
                                                                                                            //??= vasa x?.ToString() yoksa <Null> ekle
            if (_cacheManager.IsAdd(key))//bellekte bu key varmı?
            {
                invocation.ReturnValue = _cacheManager.Get(key);//varsa invocation.ReturnValue işlemi ile methodu hiç çalıştırmadan
                                                                //bu key i geri dön. yani asıl methodda olan return değeri değilde 
                                                                //bu cachedeki değeri return et ve methodu bitir. 
                return;
            }
            invocation.Proceed();//yoksa invocationu yani methodu çalıştır. 
            _cacheManager.Add(key, invocation.ReturnValue, _duration);//şimdi ise veritabanından getirdiğin değeri cache ye ekle. 
        }
    }
}
