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
   public class QualificationsManager :IQualificationsManager
    {
        private readonly IConfiguration _config;
        private readonly IQualificationsRepository _qualificationsRepository;
        public QualificationsManager(IConfiguration config, IQualificationsRepository qualificationsRepository)
        {
            _config = config;
            _qualificationsRepository = qualificationsRepository;
        }
        public async Task<Dictionary<string, dynamic>> GetQualifications(GridParameters pagingParameters)
        {

            DataSet gridDataSet = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();
            try
            {

                gridDataSet = _qualificationsRepository.GetQualifications(pagingParameters);

                Utility utility = new Utility();

                returnObj = utility.ApplyPaging(gridDataSet, pagingParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnObj;
        }
        public bool AEDQualifications(CrudModel dataObj, int userid)
        {
            bool status = false;
            try
            {
                status = _qualificationsRepository.AEDQualifications(dataObj, userid);

            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }
    }
}
