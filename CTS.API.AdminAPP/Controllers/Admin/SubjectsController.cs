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
    public class SubjectsController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ISubjectsManager _subjectsManager;
        public SubjectsController(IConfiguration config, ISubjectsManager subjectsManager)
        {
            _config = config;
            _subjectsManager = subjectsManager;
        }

        //[HttpGet]
        [HttpPost("GetSubjects")]
        public async Task<ActionResult> GetBranches([FromBody] GridParameters pagingParameters)
        {
           
            DataSet ds = new DataSet();

            DataTable dt = null;
            try
            {
                var count = 0;

                Dictionary<string, dynamic> apiResult = await _subjectsManager.GetSubjects(pagingParameters);

                dt = apiResult["data"];

                count = Convert.ToInt32(apiResult["count"]);


                return Ok(new { success = true, data = dt, Total = count });

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("AEDSubjects")]
        public async Task<ActionResult> AEDSubjects([FromBody] CrudModel dataObj)
        {
            //var userProfile = GetUserProfile();
            try
            {
                bool status = _subjectsManager.AEDSubjects(dataObj, 1);


                return Ok(new { success = status });

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
