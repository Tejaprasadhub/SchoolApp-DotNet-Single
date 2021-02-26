using CTS.Common;
using CTS.Core.DataAccess;
using CTS.DataAccess.AdminAPP.Interface;
using CTS.DataAccess.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace CTS.DataAccess.AdminAPP
{
   public class DashboardRepository : CTSRepositoryBase, IDashboardRepository
    {
        private readonly ILogger<DashboardRepository> _logger;
        public DashboardRepository(CTSContext db, ILogger<DashboardRepository> logger)
        {
            this._db = db;
            this._logger = logger;
        }

        public DataSet GetDashboard()
        {
            try
            {
                DataSet ds = new DataSet();

                Utility utility = new Utility();

                ds = _db.Execute("GetDashboard", CommandType.StoredProcedure, null, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
