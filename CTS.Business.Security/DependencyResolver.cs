using CTS.Business.AdminAPP.Interface;
using CTS.Business.Security.Interface;
using CTS.DataAccess.AdminAPP;
using CTS.DataAccess.Core;
using CTS.DataAccess.Security;
using CTS.DataAccess.Security.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.Business.Security
{
    public static class DependencyResolver
    {
        public static void ConfigureSecurityServices(this IServiceCollection services)
        {
            services.AddScoped<IAccessTokenManager, AccessTokenManager>();
            services.AddScoped<IAccessTokenRepository, AccessTokenRepository>();
        }       
    }

}
