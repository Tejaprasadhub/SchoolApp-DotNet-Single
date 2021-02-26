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
   public class AuditLogsRepository : CTSRepositoryBase, IAuditLogsRepository
    {

        private readonly ILogger<AuditLogsRepository> _logger;
        public AuditLogsRepository(CTSContext db, ILogger<AuditLogsRepository> logger)
        {
            this._db = db;
            this._logger = logger;
        }

        public DataSet GetAuditLogs()
        {
            try
            {
                DataSet ds = new DataSet();

                Utility utility = new Utility();

                ds = _db.Execute("GetAuditLogTables", CommandType.StoredProcedure, null, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet AuditlogTableDetails(GridParameters pagingParameters)
        {
            try
            {
                DataSet ds = new DataSet();

                Utility utility = new Utility();

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                {
                    {"@tablecode",pagingParameters.tablecode },
                    
                };

                ds = _db.Execute("AuditlogTableDetails", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
