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
    public class DropdownRepository : CTSRepositoryBase, IDropdownRepository
    {
        private readonly ILogger<DropdownRepository> _logger;
        public DropdownRepository(CTSContext db, ILogger<DropdownRepository> logger)
        {
            this._db = db;
            this._logger = logger;
        }

        public DataSet GetDropdowns(string spName)
        {
            try
            {
                DataSet ds = new DataSet();

                Utility utility = new Utility();

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                {
                    {"@dropDownFor",spName },
                };

                ds = _db.Execute("GetDropdowns", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetMenuOptions()
        {
            try
            {
                DataSet ds = new DataSet();

                Utility utility = new Utility();

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                {
                    {"@subDomain",utility.GetSubdomain() },
                };

                ds = _db.Execute("GetMenuOptions", CommandType.StoredProcedure, parameters);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
