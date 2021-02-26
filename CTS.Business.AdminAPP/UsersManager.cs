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
   public class UsersManager : IUsersManager
    {
        private readonly IConfiguration _config;
        private readonly IUsersRepository _usersRepository;
        public UsersManager(IConfiguration config, IUsersRepository usersRepository)
        {
            _config = config;
            _usersRepository = usersRepository;
        }

        public async Task<Dictionary<string, dynamic>> GetUsers(GridParameters pagingParameters)
        {

            DataSet gridDataSet = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();
            try
            {

                gridDataSet = _usersRepository.GetUsers(pagingParameters);

                Utility utility = new Utility();

                returnObj = utility.ApplyPaging(gridDataSet, pagingParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnObj;
        }

        public bool AEDUsers(CrudModel dataObj, string userid)
        {
            bool status = false;
            try
            {
                status = _usersRepository.AEDUsers(dataObj, userid);

            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }

        public AuthorizationResult AuthorizeComponentAccess(string routeUrl, string userid)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = _usersRepository.AuthorizeComponentAccess(routeUrl, userid);

                AuthorizationResult authorizationResult = new AuthorizationResult();
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        authorizationResult.status = dr["status"].ToString();
                        //authorizationResult.featureOptions.Add(dr["options"].ToString());
                    }
                }
                return authorizationResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable permissionsOnComponent(string routeUrl, string userid)
        {

            DataSet gridDataSet = null;

            DataTable dt = null;
            try
            {

                gridDataSet = _usersRepository.permissionsOnComponent(routeUrl,userid);

                dt = gridDataSet.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }
    }

}
