using Business.Constants;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

using Castle.DynamicProxy;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Core.Extensions;

namespace Business.BusinessAspects.Autofac
{
    //jwt
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;//her istek için httpcontext oluşur.

        public SecuredOperation(string roles)//rolleri ver
        {
            _roles = roles.Split(',');//rolleri virgül ile ayır.split metni senin belirttiğin karaktere göre ayırıp array e atar
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
