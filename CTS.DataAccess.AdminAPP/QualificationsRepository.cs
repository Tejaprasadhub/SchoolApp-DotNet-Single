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
   public class QualificationsRepository : CTSRepositoryBase, IQualificationsRepository
    {
        private readonly ILogger<QualificationsRepository> _logger;
        public QualificationsRepository(CTSContext db, ILogger<QualificationsRepository> logger)
        {
            this._db = db;
            this._logger = logger;
        }

        public DataSet GetQualifications(GridParameters pagingParameters)
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

                ds = _db.Execute("GetQualifications", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AEDQualifications(CrudModel dataObj, int userid)
        {
            try
            {
                Utility utility = new Utility();

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>()
                {
                    {"@id",dataObj.id },
                    {"@code",dataObj.code },
                    {"@title",dataObj.title },
                    {"@userid",userid },
                    {"@querytype",dataObj.querytype },
                    {"@status",dataObj.status }

                };

                DataSet ds = _db.Execute("AEDQualifications", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));


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
