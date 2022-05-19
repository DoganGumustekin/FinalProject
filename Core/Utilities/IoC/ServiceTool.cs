using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.IoC
{
    public static class ServiceTool //api deki injectionları yapabilmmizi sağlar. 
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services) //.net in servislerini al
        {
            ServiceProvider = services.BuildServiceProvider(); //ve bunları kendine build et 
            return services;
        }
    }
}
