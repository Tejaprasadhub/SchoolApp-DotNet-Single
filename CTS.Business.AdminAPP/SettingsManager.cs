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
    public class SettingsManager : ISettingsManager
    {

        private readonly IConfiguration _config;
        private readonly ISettingsRepository _settingsRepository;
        public SettingsManager(IConfiguration config, ISettingsRepository settingsRepository)
        {
            _config = config;
            _settingsRepository = settingsRepository;
        }

        public async Task<Dictionary<string, dynamic>> GetSettings(GridParameters pagingParameters)
        {

            DataSet gridDataSet = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();
            try
            {

                gridDataSet = _settingsRepository.GetSettings();

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
