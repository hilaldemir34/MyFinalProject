using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers
            (this IServiceCollection serviceCollection, ICoreModule[] modules)//IServiceCollection apimizin servis bağımlılıklarını eklediğimiz araya girmesini istediğimiz servisleri eklediğimiz koleksiyonların kendisidir.

        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);//core katmanı da dahil olmak üzere ekleyeceğimiz tüm injectionları bir arada toplayabileceğimiz yapıya dönüştü

        }
    }
}
