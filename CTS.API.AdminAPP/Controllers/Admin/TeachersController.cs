using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CTS.Business.AdminAPP.Interface;
using CTS.Model;
using CTS.Model.Teachers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CTS.API.AdminAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ITeachersManager _teachersManager;
        public TeachersController(IConfiguration config, ITeachersManager teachersManager)
        {
            _config = config;
            _teachersManager = teachersManager;
        }

        [HttpPost("GetTeachers")]
        public async Task<ActionResult> GetTeachers([FromBody] GridParameters pagingParameters)
        {

            DataSet ds = new DataSet();

            DataTable dt = null;
            try
            {
                var count = 0;

                Dictionary<string, dynamic> apiResult = await _teachersManager.GetTeachers(pagingParameters);

                dt = apiResult["data"];
                
                count = Convert.ToInt32(apiResult["count"]);


                return Ok(new { success = true, data = dt, Total = count });

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost("AEDTeachers")]
        public async Task<ActionResult> AEDTeachers([FromBody] createTeacher dataObj)
        {
            //var userProfile = GetUserProfile();
            try
            {
                bool status = _teachersManager.AEDTeachers(dataObj, 1);


                return Ok(new { success = status });

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
