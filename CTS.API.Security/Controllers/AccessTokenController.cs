using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CTS.Business.AdminAPP.Interface;
using CTS.Business.Security.Interface;
using CTS.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Renci.SshNet.Messages.Authentication;

namespace CTS.API.Security.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    public class AccessTokenController :  ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IAccessTokenManager _accessTokenManager;
        public AccessTokenController(IConfiguration config, IAccessTokenManager accessTokenManager)
        {
            _config = config;
            _accessTokenManager = accessTokenManager;
        }

        [HttpGet]
        public async Task<DataSet> GetSchoolUserDetailsBasedOnSubdomain()
        {
            DataSet ds = new DataSet();
            try
            {
                ds =   _accessTokenManager.GetSchoolUserDetailsBasedOnSubdomain();

                return ds; 
            }
            catch(Exception ex)
            {
                throw;
            }           
        }

        [HttpPost("ValidateUser")]
        public async Task<IActionResult> ValidateUser([FromBody] AuthenticationCredintials login)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _accessTokenManager.ValidateUser(login);

                if(ds.Tables[0].Rows.Count > 0)
                {
                    AuthenticationCredintials userdetails = new AuthenticationCredintials();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        userdetails.UserName = Convert.ToString(row["ctcuser_name"]);
                        userdetails.Password = Convert.ToString(row["ctcuser_password"]);
                        userdetails.UserId = Convert.ToString(row["ctcuser_id"]);
                        userdetails.UserDisplayName = Convert.ToString(row["ctcuser_disname"]);
                        userdetails.UserType = Convert.ToString(row["ctcuser_type"]);
                        userdetails.UserStatus = Convert.ToString(row["ctcuser_status"]);
                        userdetails.UserBranch = Convert.ToString(row["ctcuser_branch_id"]);
                    }

                    var userdata = userdetails;

                    SecurityTokenValidator securityTokenValidator = new SecurityTokenValidator();
                    var token = securityTokenValidator.CreateToken(userdata, _config);

                    return Ok(new
                    {
                        success = true,
                        token = token,
                        warningMinutes = 5,
                        timeoutMinutes = 20,
                        userId=userdata.UserId
                    });
                }
                else
                {
                    return Ok(new { success = false });
                }
              
            }
            catch (Exception ex)
            {
                throw;
            }            
        }
             

    }
}