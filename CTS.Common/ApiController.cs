using CTS.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.Common
{
    [Authorize(Policy = "ApiResourceAuthorization")]
    [Route("api/[controller]")]
   public  class ApiController : ControllerBase
    {
        private UserProfile _profile;
        [HttpGet]
        public UserProfile GetUserProfile()
        {
            if(_profile == null)
            {
                _profile = HttpContext.GetUserProfile();
            }

            return _profile;
        }

      
    }
}
