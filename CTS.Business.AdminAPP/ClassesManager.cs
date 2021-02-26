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
   public class ClassesManager : IClassesManager
    {

        private readonly IConfiguration _config;
        private readonly IClassesRepository _classesRepository;
        public ClassesManager(IConfiguration config, IClassesRepository classesRepository)
        {
            _config = config;
            _classesRepository = classesRepository;
        }

        public async Task<Dictionary<string, dynamic>> GetClasses(GridParameters pagingParameters)
        {

            DataSet gridDataSet = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();
            try
            {

                gridDataSet = _classesRepository.GetClasses(pagingParameters);

                Utility utility = new Utility();

                returnObj = utility.ApplyPaging(gridDataSet, pagingParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnObj;
        }

        public bool AEDClasses(CrudModel dataObj, int userid)
        {
            bool status = false;
            try
            {
                status = _classesRepository.AEDClasses(dataObj, userid);

            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }
    }
}
