using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CTS.Business.AdminAPP.Interface;
using CTS.Common;
using CTS.Model;
using CTS.Model.Branches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CTS.API.AdminAPP.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BranchesController : ApiController
    {
        private readonly IConfiguration _config;
        private readonly IBrnachesManager _branchesManager;
        public BranchesController(IConfiguration config, IBrnachesManager branchesManager)
        {
            _config = config;
            _branchesManager = branchesManager;
        }

        //[HttpGet]
        [HttpPost("GetBranches")]
        public async Task<ActionResult> GetBranches([FromBody]GridParameters pagingParameters)
        {
            List<Branches> branches = new List<Branches>();

            DataSet ds = new DataSet();

            UserProfile userProfile = GetUserProfile(); 

            DataTable dt = null;
            try
            {
                var count = 0;

                Dictionary<string,dynamic> apiResult = await _branchesManager.GetBranches(pagingParameters);

                dt = apiResult["data"];

                count = Convert.ToInt32(apiResult["count"]);


                return Ok(new { success = true, data = dt, Total = count });

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("AEDBranches")]
        public async Task<ActionResult> AEDBranches([FromBody]CrudModel dataObj)
        {
            //var userProfile = GetUserProfile();
            try
            {
                bool status =  _branchesManager.AEDBranches(dataObj,1);


                return Ok(new { success = status });

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
