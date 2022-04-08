using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        //this ClaimsPrincipal claimsPrincipal bir kişinin claimlerine ulaşmak için .net te olan class
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType) //hangi claim type yi bulmak için yazılan class
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();//? = null olabilir token istenmemiş olabilir. ilgili claim type yi getir.
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal) //çoğunlukla roller lazım
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
