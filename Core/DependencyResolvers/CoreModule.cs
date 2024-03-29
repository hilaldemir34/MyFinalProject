﻿using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection seviceCollection)
        {
            seviceCollection.AddMemoryCache();
            seviceCollection.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
            seviceCollection.AddSingleton<ICacheManager,MemoryCacheManager>();
        }
    }
}
