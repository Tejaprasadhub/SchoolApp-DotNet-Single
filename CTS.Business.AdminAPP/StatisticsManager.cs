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
    public class StatisticsManager : IStatisticsManager
    {

        private readonly IConfiguration _config;
        private readonly IStatisticsRepository _StatisticsRepository;
        public StatisticsManager(IConfiguration config, IStatisticsRepository StatisticsRepository)
        {
            _config = config;
            _StatisticsRepository = StatisticsRepository;
        }

        public async Task<Dictionary<string, dynamic>> GetStatistics(GridParameters pagingParameters)
        {

            DataSet gridDataSet = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();
            try
            {

                gridDataSet = _StatisticsRepository.GetStatistics();

                Utility utility = new Utility();

                returnObj = utility.ApplyPaging(gridDataSet, pagingParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnObj;
        }
    }
}
