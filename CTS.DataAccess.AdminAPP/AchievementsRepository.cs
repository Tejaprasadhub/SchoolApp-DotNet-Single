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
    public class AchievementsRepository : CTSRepositoryBase, IAchievementsRepository
    {

        private readonly ILogger<AchievementsRepository> _logger;
        public AchievementsRepository(CTSContext db, ILogger<AchievementsRepository> logger)
        {
            this._db = db;
            this._logger = logger;
        }

        public DataSet GetAchievement(GridParameters pagingParameters)
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


                ds = _db.Execute("GetAchievements", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AEDAchievements(CrudModel dataObj, int userid)
        {
            try
            {
                Utility utility = new Utility();

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>()
                {
                    {"@id",dataObj.id },
                    {"@branchid",dataObj.branchid },
                    {"@title",dataObj.title },
                     {"@image",dataObj.image },
                    {"@date",dataObj.date },
                    {"@userid",userid },
                    {"@querytype",dataObj.querytype },
                    {"@status",dataObj.status }
                };

                _db.Execute("AEDAchievements", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
