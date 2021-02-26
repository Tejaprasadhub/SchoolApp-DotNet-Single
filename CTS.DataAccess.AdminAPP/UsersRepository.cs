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
    public class UsersRepository : CTSRepositoryBase, IUsersRepository
    {
        private readonly ILogger<UsersRepository> _logger;
        public UsersRepository(CTSContext db, ILogger<UsersRepository> logger)
        {
            this._db = db;
            this._logger = logger;
        }

        public DataSet GetUsers(GridParameters pagingParameters)
        {
            try
            {
                DataSet ds = new DataSet();

                Utility utility = new Utility();
                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                {
                    {"@queryType",pagingParameters.queryType },
                    {"@idValue",pagingParameters.idValue }
                };

                ds = _db.Execute("GetUsers", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AEDUsers(CrudModel dataObj, string userid)
        {
            try
            {
                Utility utility = new Utility();

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>()
                {
                    {"@id",dataObj.id },
                    {"@type",dataObj.usertype },
                    {"@name",dataObj.userName },
                    {"@branchid",dataObj.branchid },
                    {"@disname",dataObj.dispName },
                    {"@password",dataObj.password },
                    {"@status",dataObj.userstatus },
                    {"@userid",userid },
                    {"@querytype",dataObj.querytype },
                    {"@email",dataObj.email },
                    {"@teacher",dataObj.teacher },
                    {"@parent",dataObj.parent }
                };

                DataSet ds = _db.Execute("AEDUsers", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                if (dataObj.querytype == 1 && ds.Tables[0].Rows.Count > 0)
                {
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet AuthorizeComponentAccess(string routeUrl, string userid)
        {
            try
            {
                DataSet ds = new DataSet();
                Utility utility = new Utility();
                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                {
                    {"@routeUrl",routeUrl },
                    {"@userid",userid }
                };
                ds = _db.Execute("AuthorizeComponentAccess", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet permissionsOnComponent(string routeUrl, string userid)
        {
            try
            {
                DataSet ds = new DataSet();

                Utility utility = new Utility();

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                {
                   {"@routeUrl",routeUrl },
                    {"@userid",userid }
                };

                ds = _db.Execute("permissionsOnComponent", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
