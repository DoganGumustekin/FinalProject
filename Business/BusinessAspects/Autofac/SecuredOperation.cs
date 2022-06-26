using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Business.Constans;
using Core.Extensions;

namespace Business.BusinessAspects.Autofac //add methodu içine if yetkisi varmı yokmu yu çalıştırmam lazım ama ben her method için bunu yazmamalıyım o yüzden bu aspect i yazıyorum.
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles; 
        private IHttpContextAccessor _httpContextAccessor; //IHttpContextAccessor = jwt yide göndererek bir yere binlerce kişi istek yapabilir. 
                                                           //burada her bir kişi için httpcontex oluşur. 
        public SecuredOperation(string roles) //bana rolleri ver 
        {
            _roles = roles.Split(','); //roles.split = bir metni benim belirttiğim karaktere göre array e at. 
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>(); //aoutofac ile oluşturduğum servis mimarisine ulaş onları getservice et. 

        }

        protected override void OnBefore(IInvocation invocation) //methodun önünde çalıştır.
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();//o anki kullanıcının claim rollerini bul 
            foreach (var role in _roles) 
            {
                if (roleClaims.Contains(role))//claimlerinin içinde ilgili rol varsa 
                {
                    return; //methodu çalıştırmaya devam et yani claimi varsa onebefore yi bitir hata verme 
                }
            }
            throw new Exception(Messages.AuthorizationDenied); //yoksa yetkin yok hatası ver
        }
        //https://github.com/ismailkaygisiz/ArtChitecture/blob/main/Core/Utilities/Interceptors/MethodInterception.cs
    }
}
