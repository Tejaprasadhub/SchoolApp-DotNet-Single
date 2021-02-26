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
   public class EventsRepository : CTSRepositoryBase,IEventsRepository
    {
        private readonly ILogger<EventsRepository> _logger;
        public EventsRepository(CTSContext db, ILogger<EventsRepository> logger)
        {
            this._db = db;
            this._logger = logger;
        }

        public DataSet GetEvents()
        {
            try
            {
                DataSet ds = new DataSet();

                Utility utility = new Utility();

                ds = _db.Execute("GetEvents", CommandType.StoredProcedure, null, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AEDEvents(CrudModel dataObj, int userid)
        {
            try
            {
                Utility utility = new Utility();

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>()
                {
                    {"@id",dataObj.id },
                    {"@branchid",dataObj.branchid },
                    {"@name",dataObj.name },
                    {"@category",dataObj.category },
                    {"@description",dataObj.description },
                    {"@image",dataObj.image },
                    {"@accept_registrations",dataObj.accept_registrations },
                    {"@userid",userid },
                    {"@querytype",dataObj.querytype }
                };

                _db.Execute("AEDEvents", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
