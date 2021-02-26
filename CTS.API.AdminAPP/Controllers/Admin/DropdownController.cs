using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CTS.Business.AdminAPP.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CTS.API.AdminAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropdownController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IDropdownManager _dropdownManager;
        public DropdownController(IConfiguration config, IDropdownManager dropdownManager)
        {
            _config = config;
            _dropdownManager = dropdownManager;
        }

        [HttpPost("GetDropdowns")]
        public async Task<ActionResult> GetDropdowns(List<string> data)
        {

            DataTable dt = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();

            try
            {
                foreach (string spName in data)
                {
                    dt =  _dropdownManager.GetDropdowns(spName);

                    returnObj.Add(spName, dt);
                }               

                return Ok(new { success = true, data = returnObj });

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost("GetMenuOptions")]
        public async Task<ActionResult> GetMenuOptions(string data="")
        {

            DataTable dt = null;

            try
            {
                
                dt = _dropdownManager.GetMenuOptions();               

                return Ok(new { success = true, data = dt });

            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
