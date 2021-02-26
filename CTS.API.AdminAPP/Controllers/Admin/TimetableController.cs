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
    public class TimetableController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ITimeTableManager _timetableManager;
        public TimetableController(IConfiguration config, ITimeTableManager timetableManager)
        {
            _config = config;
            _timetableManager = timetableManager;
        }

        [HttpPost("GetTimetable")]
        public async Task<ActionResult> GetTimetable([FromBody] GridParameters pagingParameters)
        {

            DataSet ds = new DataSet();

            DataTable dt = null;
            try
            {
                var count = 0;

                Dictionary<string, dynamic> apiResult = await _timetableManager.GetTimetable(pagingParameters);

                dt = apiResult["data"];

                count = Convert.ToInt32(apiResult["count"]);


                return Ok(new { success = true, data = dt, Total = count });

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost("AEDTimetable")]
        public async Task<ActionResult> AEDTimetable([FromBody] CrudModel dataObj)
        {
            //var userProfile = GetUserProfile();
            try
            {
                bool status = _timetableManager.AEDTimetable(dataObj, 1);


                return Ok(new { success = status });

            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
