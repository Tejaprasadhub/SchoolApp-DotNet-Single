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
    public class AuditLogsManager :  IAuditLogsManager
    {
        private readonly IConfiguration _config;
        private readonly IAuditLogsRepository _auditLogsRepository;
        public AuditLogsManager(IConfiguration config, IAuditLogsRepository auditLogsRepository)
        {
            _config = config;
            _auditLogsRepository = auditLogsRepository;
        }

        public async Task<Dictionary<string, dynamic>> GetAuditLogs(GridParameters pagingParameters)
        {

            DataSet gridDataSet = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();
            try
            {

                gridDataSet = _auditLogsRepository.GetAuditLogs();

                Utility utility = new Utility();

                returnObj = utility.ApplyPaging(gridDataSet, pagingParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnObj;
        }
        public async Task<Dictionary<string, dynamic>> AuditlogTableDetails(GridParameters pagingParameters)
        {

            DataSet gridDataSet = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();
            try
            {

                gridDataSet = _auditLogsRepository.AuditlogTableDetails(pagingParameters);

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
