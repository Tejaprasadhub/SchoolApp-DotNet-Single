using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    public class QualificationsController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IQualificationsManager _qualificationsManager;
        public QualificationsController(IConfiguration config, IQualificationsManager qualificationsManager)
        {
            _config = config;
            _qualificationsManager = qualificationsManager;
        }

        //[HttpGet]
        [HttpPost("GetQualifications")]
        public async Task<ActionResult> GetQualifications([FromBody] GridParameters pagingParameters)
        {
        

            DataSet ds = new DataSet();

            DataTable dt = null;
            try
            {
                var count = 0;

                Dictionary<string, dynamic> apiResult = await _qualificationsManager.GetQualifications(pagingParameters);

                dt = apiResult["data"];

                count = Convert.ToInt32(apiResult["count"]);


                return Ok(new { success = true, data = dt, Total = count });

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost("AEDQualifications")]
        public async Task<ActionResult> AEDQualifications([FromBody] CrudModel dataObj)
        {
            //var userProfile = GetUserProfile();
            try
            {
                bool status = _qualificationsManager.AEDQualifications(dataObj, 1);


                return Ok(new { success = status });

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
