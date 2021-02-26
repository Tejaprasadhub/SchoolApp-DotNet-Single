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
    public class DashboardController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly IDashboardManager _dashboardManager;
        public DashboardController(IConfiguration config, IDashboardManager dashboardManager)
        {
            _config = config;
            _dashboardManager = dashboardManager;
        }

        [HttpPost("GetDashboard")]
        public async Task<ActionResult> GetDashboard([FromBody] GridParameters pagingParameters)
        {

            DataSet ds = new DataSet();

            DataTable dt = null;
            try
            {
                var count = 0;

                Dictionary<string, dynamic> apiResult = await _dashboardManager.GetDashboard(pagingParameters);

                dt = apiResult["data"];

                count = Convert.ToInt32(apiResult["count"]);


                return Ok(new { success = true, data = dt, Total = count });

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
