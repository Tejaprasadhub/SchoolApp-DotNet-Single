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
    public class AuditLogsController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IAuditLogsManager _auditLogsManager;
        public AuditLogsController(IConfiguration config, IAuditLogsManager auditLogsManager)
        {
            _config = config;
            _auditLogsManager = auditLogsManager;
        }

        [HttpPost("GetAuditLogTables")]
        public async Task<ActionResult> GetAuditLogs([FromBody] GridParameters pagingParameters)
        {

            DataSet ds = new DataSet();

            DataTable dt = null;
            try
            {
                var count = 0;

                Dictionary<string, dynamic> apiResult = await _auditLogsManager.GetAuditLogs(pagingParameters);

                dt = apiResult["data"];

                count = Convert.ToInt32(apiResult["count"]);


                return Ok(new { success = true, data = dt, Total = count });

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost("AuditlogTableDetails")]
        public async Task<ActionResult> AuditlogTableDetails([FromBody] GridParameters pagingParameters)
        {

            DataSet ds = new DataSet();

            DataTable dt = null;
            try
            {
                var count = 0;

                Dictionary<string, dynamic> apiResult = await _auditLogsManager.AuditlogTableDetails(pagingParameters);

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
