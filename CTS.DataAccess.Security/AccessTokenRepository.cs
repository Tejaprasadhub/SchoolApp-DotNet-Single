using CTS.Common;
using CTS.Core.DataAccess;
using CTS.DataAccess.Core;
using CTS.DataAccess.Security.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.Security
{
    public class AccessTokenRepository : CTSRepositoryBase ,IAccessTokenRepository
    {
        private readonly ILogger<AccessTokenRepository> _logger;
        public AccessTokenRepository(CTSContext db, ILogger<AccessTokenRepository> logger)
        {
            this._db = db;
            this._logger = logger;
        }

        public DataSet GetSchoolUserDetailsBasedOnSubdomain()
        {
            try
            {
                DataSet ds = new DataSet();

                string subdomain = "PRIVATE";
                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                {
                    {"@subDomain",subdomain }
                };
                ds = _db.Execute("GetSchoolUserDetailsBasedOnSubdomain", CommandType.StoredProcedure, parameters);
                return ds;
            }catch(Exception ex)
            {
                throw ex;
            }
            
        }  

        public DataSet ValidateUser(AuthenticationCredintials login)
        {
            try
            {
                DataSet ds = new DataSet();
                Utility utility = new Utility();
                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                {
                    {"@userName",login.UserName },
                    {"@password",login.Password }
                };
                ds = _db.Execute("ValidateUser", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

       
    }
}
