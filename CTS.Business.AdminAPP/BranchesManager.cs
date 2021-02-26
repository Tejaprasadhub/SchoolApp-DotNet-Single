using CTS.Business.AdminAPP.Interface;
using CTS.Common;
using CTS.DataAccess.AdminAPP.Interface;
using CTS.Model;
using CTS.Model.Branches;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Business.AdminAPP
{
   public class BranchesManager : IBrnachesManager
    {
        private readonly IConfiguration _config;
        private readonly IBranchesRepository _branchesRepository;
        public BranchesManager(IConfiguration config,IBranchesRepository branchesRepository)
        {
            _config = config;
            _branchesRepository = branchesRepository;
        }
        public async Task<Dictionary<string,dynamic>> GetBranches(GridParameters pagingParameters)
        {
           
            DataSet gridDataSet = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();
            try
            {

                gridDataSet = _branchesRepository.GetBranches(pagingParameters);

                Utility utility = new Utility();

                returnObj = utility.ApplyPaging(gridDataSet,pagingParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnObj;
        }

        public bool AEDBranches(CrudModel dataObj,int userid)
        {
            bool status = false;
            try
            {
                 status = _branchesRepository.AEDBranches(dataObj,userid);
                
            }
            catch(Exception ex)
            {
                throw;
            }
            return status;
        }




    }
}
