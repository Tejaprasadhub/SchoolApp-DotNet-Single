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
    public class DashboardManager : IDashboardManager
    {
        private readonly IConfiguration _config;
        private readonly IDashboardRepository _dashboardRepository;
        public DashboardManager(IConfiguration config, IDashboardRepository dashboardRepository)
        {
            _config = config;
            _dashboardRepository = dashboardRepository;
        }

        public async Task<Dictionary<string, dynamic>> GetDashboard(GridParameters pagingParameters)
        {

            DataSet gridDataSet = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();
            try
            {

                gridDataSet = _dashboardRepository.GetDashboard();

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
