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
    public class ClassesRepository : CTSRepositoryBase, IClassesRepository
    {
        private readonly ILogger<ClassesRepository> _logger;
        public ClassesRepository(CTSContext db, ILogger<ClassesRepository> logger)
        {
            this._db = db;
            this._logger = logger;
        }

        public DataSet GetClasses(GridParameters pagingParameters)
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

                ds = _db.Execute("GetClasses", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AEDClasses(CrudModel dataObj, int userid)
        {
            try
            {
                Utility utility = new Utility();

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>()
                {
                    {"@id",dataObj.id },
                    {"@name",dataObj.name },
                    {"@noofsections",dataObj.noofsections },
                    {"@userid",userid },
                    {"@querytype",dataObj.querytype },
                    {"@status",dataObj.status }

                };

                DataSet ds = _db.Execute("AEDClasses", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

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
    }
}
