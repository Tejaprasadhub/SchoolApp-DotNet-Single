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
    public class ClassesController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly IClassesManager _classesManager;
        public ClassesController(IConfiguration config, IClassesManager classesManager)
        {
            _config = config;
            _classesManager = classesManager;
        }

        [HttpPost("GetClasses")]
        public async Task<ActionResult> GetClasses([FromBody] GridParameters pagingParameters)
        {

            DataSet ds = new DataSet();

            DataTable dt = null;
            try
            {
                var count = 0;

                Dictionary<string, dynamic> apiResult = await _classesManager.GetClasses(pagingParameters);

                dt = apiResult["data"];

                count = Convert.ToInt32(apiResult["count"]);


                return Ok(new { success = true, data = dt, Total = count });

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost("AEDClasses")]
        public async Task<ActionResult> AEDClasses([FromBody] CrudModel dataObj)
        {
            //var userProfile = GetUserProfile();
            try
            {
                bool status = _classesManager.AEDClasses(dataObj, 1);


                return Ok(new { success = status });

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
