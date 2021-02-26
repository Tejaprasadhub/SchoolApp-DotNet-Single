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
   public class FeesRepository : CTSRepositoryBase, IFeesRepository
    {
        private readonly ILogger<FeesRepository> _logger;
        public FeesRepository(CTSContext db, ILogger<FeesRepository> logger)
        {
            this._db = db;
            this._logger = logger;
        }

        public DataSet GetFees()
        {
            try
            {
                DataSet ds = new DataSet();

                Utility utility = new Utility();

                ds = _db.Execute("GetFees", CommandType.StoredProcedure, null, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
