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
    public class RoleAccessManager : IRoleAccessManager
    {

        private readonly IConfiguration _config;
        private readonly IRoleAccessRepository _roleAccessRepository;
        public RoleAccessManager(IConfiguration config, IRoleAccessRepository roleAccessRepository)
        {
            _config = config;
            _roleAccessRepository = roleAccessRepository;
        }

        public async Task<Dictionary<string, dynamic>> GetRoleAccess(GridParameters pagingParameters)
        {

            DataSet gridDataSet = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();
            try
            {

                gridDataSet = _roleAccessRepository.GetRoleAccess();

                Utility utility = new Utility();

                returnObj = utility.ApplyPaging(gridDataSet, pagingParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnObj;
        }

        public bool AEDRoleAccess(RoleAccessData dataObj, string userid)
        {
            bool status = false;
            try
            {
                status = _roleAccessRepository.AEDRoleAccess(dataObj, userid);

            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }

        public DataSet GetUserFeatures(string userid)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = _roleAccessRepository.GetUserFeatures(userid);

                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetSchoolFeatures()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = _roleAccessRepository.GetSchoolFeatures();

                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
