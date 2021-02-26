using CTS.Common;
using CTS.Core.DataAccess;
using CTS.DataAccess.AdminAPP.Interface;
using CTS.DataAccess.Core;
using CTS.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.AdminAPP
{
   public class RoleAccessRepository : CTSRepositoryBase, IRoleAccessRepository
    {
        private readonly ILogger<RoleAccessRepository> _logger;
        public RoleAccessRepository(CTSContext db, ILogger<RoleAccessRepository> logger)
        {
            this._db = db;
            this._logger = logger;
        }

        public DataSet GetRoleAccess()
        {
            try
            {
                DataSet ds = new DataSet();

                Utility utility = new Utility();

                ds = _db.Execute("GetRoleAccess", CommandType.StoredProcedure, null, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AEDRoleAccess(RoleAccessData dataObj, string userid)
        {
            try
            {
                Utility utility = new Utility();

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>()
                {
                 
                    {"@featureId",dataObj.featureId },
                    {"@featureIndex",dataObj.featureIndex },
                    {"@userid",userid },
                    {"@status",dataObj.status }
                };

                _db.Execute("AEDRoleAccess", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet GetUserFeatures(string userid)
        {
            try
            {
                DataSet ds = new DataSet();
                Utility utility = new Utility();
                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                {
                    {"@userid",userid },
                    {"@subdomain",utility.GetSubdomain() }
                };
                ds = _db.Execute("GetUserFeatures", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetSchoolFeatures()
        {
            try
            {
                DataSet ds = new DataSet();
                Utility utility = new Utility();
                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                {
                    {"@subdomain",utility.GetSubdomain() }
                };
                ds = _db.Execute("GetSchoolFeatures", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
