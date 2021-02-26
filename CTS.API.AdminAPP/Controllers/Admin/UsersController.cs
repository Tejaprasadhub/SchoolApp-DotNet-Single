using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CTS.Business.AdminAPP.Interface;
using CTS.Common;
using CTS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CTS.API.AdminAPP.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ApiController
    {
        private readonly IConfiguration _config;
        private readonly IUsersManager _usersManager;
        public UsersController(IConfiguration config, IUsersManager usersManager)
        {
            _config = config;
            _usersManager = usersManager;
        }

        [HttpPost("GetUsers")]
        public async Task<ActionResult> GetUsers([FromBody] GridParameters pagingParameters)
        {

            DataSet ds = new DataSet();

            DataTable dt = null;
            try
            {
                var count = 0;

                Dictionary<string, dynamic> apiResult = await _usersManager.GetUsers(pagingParameters);

                dt = apiResult["data"];

                count = Convert.ToInt32(apiResult["count"]);


                return Ok(new { success = true, data = dt, Total = count });

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("AEDUsers")]
        public async Task<ActionResult> AEDUsers([FromBody]CrudModel dataObj)
        {
            var userProfile = GetUserProfile();
            try
            {
                bool status = _usersManager.AEDUsers(dataObj, userProfile.UserId);


                return Ok(new { success = status });

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("authorizeroute")]
        public async Task<ActionResult> AuthorizeRoute([FromBody] dynamic body)
        {
            String routeUrl = body.routeUrl.ToString();

            string OptionalParameters = string.Empty;

            var userProfile = GetUserProfile();

            DataTable permissionsDataTable = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();

            if (routeUrl.IndexOf('?') > -1)
            {
                int optionalParamCount = routeUrl.IndexOf('?') + 1;
                //remove substring
                OptionalParameters = routeUrl.Substring(optionalParamCount);

                routeUrl = routeUrl.Substring(0, routeUrl.IndexOf('?'));
            }
            if (routeUrl.IndexOf('(') > -1)
            {
                //if this includes a named outlets, validate the outlet
                routeUrl = routeUrl.Substring(routeUrl.IndexOf('(') + 1, routeUrl.IndexOf(')') - routeUrl.IndexOf('(') - 1);

                //if we have multiple outlets, validate the first as the others would have been validated in previous calls
                if (routeUrl.IndexOf('/') > -1)
                {
                    routeUrl = routeUrl.Substring(0, routeUrl.IndexOf('/'));
                }
            }
            var result = _usersManager.AuthorizeComponentAccess(routeUrl, userProfile.UserId);

            permissionsDataTable = _usersManager.permissionsOnComponent(routeUrl, userProfile.UserId);

            return Ok(new { status = result.status, featureOptions = permissionsDataTable });
        }
    }

}
