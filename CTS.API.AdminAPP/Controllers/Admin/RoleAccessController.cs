using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CTS.Business.AdminAPP.Interface;
using CTS.Business.Security.Interface;
using CTS.Common;
using CTS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CTS.API.AdminAPP.Controllers
{
    [Route("api/[controller]")]
    public class RoleAccessController : ApiController
    {

        private readonly IConfiguration _config;
        private readonly IRoleAccessManager _roleAccessManager;
        private readonly IAccessTokenManager _accessTokenManager;
        public RoleAccessController(IConfiguration config, IRoleAccessManager roleAccessManager, IAccessTokenManager accessTokenManager)
        {
            _config = config;
            _roleAccessManager = roleAccessManager;
            _accessTokenManager = accessTokenManager;
        }

        [HttpPost("GetRoleAccess")]
        public async Task<ActionResult> GetTeachers([FromBody] GridParameters pagingParameters)
        {
            //var userProfile = GetUserProfile();

            DataSet ds = new DataSet();

            DataTable dt = null;
            try
            {
                var count = 0;

                Dictionary<string, dynamic> apiResult = await _roleAccessManager.GetRoleAccess(pagingParameters);

                dt = apiResult["data"];

                count = Convert.ToInt32(apiResult["count"]);


                return Ok(new { success = true, data = dt, Total = count });

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("AEDRoleAccess")]
        [ResponseCache(NoStore =true)]
        public async Task<ActionResult> AEDRoleAccess([FromBody] RoleAccessDataObject inputData)
        {
            bool status = false;

            UserProfile userProfile = GetUserProfile();
            try
            {
                foreach (var dataObj in inputData.listData)
                {
                   status = _roleAccessManager.AEDRoleAccess(dataObj,inputData.id);
                }

                return Ok(new { success = status });

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("UserFeatures")]
        public async Task<DataTable> GetUserFeatures([FromBody]string id)
        {
            DataSet ds = new DataSet();

            var userProfile = GetUserProfile();

            try
            {
                ds = _roleAccessManager.GetUserFeatures(id);

                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ds = _roleAccessManager.GetSchoolFeatures();
                }

                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
