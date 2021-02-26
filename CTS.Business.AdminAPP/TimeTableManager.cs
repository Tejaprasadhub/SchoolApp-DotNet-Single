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
    public class TimeTableManager : ITimeTableManager
    {
        private readonly IConfiguration _config;
        private readonly ITimetableRepository _timeTableRepository;
        public TimeTableManager(IConfiguration config, ITimetableRepository timeTableRepository)
        {
            _config = config;
            _timeTableRepository = timeTableRepository;
        }

        public async Task<Dictionary<string, dynamic>> GetTimetable(GridParameters pagingParameters)
        {

            DataSet gridDataSet = new DataSet();

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();
            try
            {

                gridDataSet =  _timeTableRepository.GetTimetable(pagingParameters);

                Utility utility = new Utility();

                returnObj = utility.ApplyPaging(gridDataSet, pagingParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnObj;
        }

        public bool AEDTimetable(CrudModel dataObj, int userid)
        {
            bool status = false;
            try
            {
                status = _timeTableRepository.AEDTimetable(dataObj, userid);

            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }
    }
}
