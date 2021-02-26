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
    public class EventsController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly IEventsManager _eventsManager;
        public EventsController(IConfiguration config, IEventsManager eventsManager)
        {
            _config = config;
            _eventsManager = eventsManager;
        }

        [HttpPost("GetEvents")]
        public async Task<ActionResult> GetEvents([FromBody] GridParameters pagingParameters)
        {

            DataSet ds = new DataSet();

            DataTable dt = null;
            try
            {
                var count = 0;

                Dictionary<string, dynamic> apiResult = await _eventsManager.GetEvents(pagingParameters);

                dt = apiResult["data"];

                count = Convert.ToInt32(apiResult["count"]);


                return Ok(new { success = true, data = dt, Total = count });

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("AEDEvents")]
        public async Task<ActionResult> AEDEvents([FromBody] CrudModel dataObj)
        {
            //var userProfile = GetUserProfile();
            try
            {
                bool status = _eventsManager.AEDEvents(dataObj, 1);


                return Ok(new { success = status });

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
