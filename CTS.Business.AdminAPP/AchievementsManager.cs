using CTS.Business.AdminAPP.Interface;
using CTS.Common;
using CTS.DataAccess.AdminAPP.Interface;
using CTS.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Business.AdminAPP
{
   public  class AchievementsManager : IAchievementManager
    {

        private readonly IConfiguration _config;
        private readonly IAchievementsRepository _achievementsRepository;
        public AchievementsManager(IConfiguration config, IAchievementsRepository achievementsRepository)
        {
            _config = config;
            _achievementsRepository = achievementsRepository;
        }

        public async Task<Dictionary<string, dynamic>> GetAchievement(GridParameters pagingParameters)
        {

            DataSet gridDataSet = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();
            try
            {

                gridDataSet = _achievementsRepository.GetAchievement(pagingParameters);

                Utility utility = new Utility();

                returnObj = utility.ApplyPaging(gridDataSet, pagingParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnObj;
        }

        public bool AEDAchievements(CrudModel dataObj, int userid)
        {
            bool status = false;
            try
            {
                status = _achievementsRepository.AEDAchievements(dataObj, userid);

            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }
    }
}
