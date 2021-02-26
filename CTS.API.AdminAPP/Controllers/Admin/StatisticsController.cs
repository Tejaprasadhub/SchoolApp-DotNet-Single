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
    public class StatisticsController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IStatisticsManager _statisticsManager;
        public StatisticsController(IConfiguration config, IStatisticsManager StatisticsManager)
        {
            _config = config;
            _statisticsManager = StatisticsManager;
        }

        [HttpPost("GetStatistics")]
        public async Task<ActionResult> GetStatistics([FromBody] GridParameters pagingParameters)
        {

            DataSet ds = new DataSet();

            DataTable dt = null;
            try
            {
                var count = 0;

                Dictionary<string, dynamic> apiResult = await _statisticsManager.GetStatistics(pagingParameters);

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
