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
    public class SubjectsManager : ISubjectsManager
    {
        private readonly IConfiguration _config;
        private readonly ISubjectsRepository _subjectsRepository;
        public SubjectsManager(IConfiguration config, ISubjectsRepository subjectsRepository)
        {
            _config = config;
            _subjectsRepository = subjectsRepository;
        }
        public async Task<Dictionary<string, dynamic>> GetSubjects(GridParameters pagingParameters)
        {

            DataSet gridDataSet = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();
            try
            {

                gridDataSet = _subjectsRepository.GetSubjects(pagingParameters);

                Utility utility = new Utility();

                returnObj = utility.ApplyPaging(gridDataSet, pagingParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnObj;
        }
        public bool AEDSubjects(CrudModel dataObj, int userid)
        {
            bool status = false;
            try
            {
                status = _subjectsRepository.AEDSubjects(dataObj, userid);

            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }
    }
}
