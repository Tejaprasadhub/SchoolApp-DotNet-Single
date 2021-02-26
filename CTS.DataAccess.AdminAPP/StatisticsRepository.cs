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
   public class StatisticsRepository : CTSRepositoryBase, IStatisticsRepository
    {

        private readonly ILogger<StatisticsRepository> _logger;
        public StatisticsRepository(CTSContext db, ILogger<StatisticsRepository> logger)
        {
            this._db = db;
            this._logger = logger;
        }

        public DataSet GetStatistics()
        {
            try
            {
                DataSet ds = new DataSet();

                Utility utility = new Utility();

                ds = _db.Execute("GetStatistics", CommandType.StoredProcedure, null, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
