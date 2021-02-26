using CTS.Business.AdminAPP.Interface;
using CTS.Common;
using CTS.DataAccess.AdminAPP.Interface;
using CTS.Model;
using CTS.Model.Teachers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Business.AdminAPP
{
    public class TeachersManager : ITeachersManager
    {
        private readonly IConfiguration _config;
        private readonly ITeachersRepository _teachersRepository;
        public TeachersManager(IConfiguration config, ITeachersRepository teachersRepository)
        {
            _config = config;
            _teachersRepository = teachersRepository;
        }

        public async Task<Dictionary<string, dynamic>> GetTeachers(GridParameters pagingParameters)
        {

            DataSet gridDataSet = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();
            try
            {

                gridDataSet = _teachersRepository.GetTeachers(pagingParameters);

                Utility utility = new Utility();

                returnObj = utility.ApplyPaging(gridDataSet, pagingParameters,"GetTeachers");

               

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnObj;
        }


        public bool AEDTeachers(createTeacher dataObj, int userid)
        {
            bool status = false;
            try
            {
                status = _teachersRepository.AEDTeachers(dataObj, userid);

            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }
    }
}
