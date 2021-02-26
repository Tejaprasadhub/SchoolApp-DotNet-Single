using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CTS.Business.AdminAPP.Interface;
using CTS.Model;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CTS.API.AdminAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly IParentsManager _parentsManager;
        public ParentsController(IConfiguration config, IParentsManager parentsManager)
        {
            _config = config;
            _parentsManager = parentsManager;
        }

        //[HttpGet]
        [HttpPost("GetParents")]
        public async Task<ActionResult> GetParents([FromBody] GridParameters pagingParameters)
        {
          

            DataSet ds = new DataSet();

            DataTable dt = null;
            try
            {
                var count = 0;

                Dictionary<string, dynamic> apiResult = await _parentsManager.GetParents(pagingParameters);

                dt = apiResult["data"];

                count = Convert.ToInt32(apiResult["count"]);


                return Ok(new { success = true, data = dt, Total = count });

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost("AEDParents")]
        public async Task<ActionResult> AEDParents([FromBody] CrudModel dataObj)
        {
            //var userProfile = GetUserProfile();
            try
            {
                bool status = _parentsManager.AEDParents(dataObj, 1);


                return Ok(new { success = status });

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
