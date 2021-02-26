using CTS.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace CTS.Common
{
   public static class HttpContextExtensions 
    {
        public static UserProfile GetUserProfile(this HttpContext context)
        {
            if (context.User == null || context.User.Claims == null || context.User.Claims.ToList().Count == 0) return null;
            return UserProfile.LoadFromJson(context.User.Claims.ToList().First(c => c.Type == "UserProfile").Value);
        }       
    }
}
