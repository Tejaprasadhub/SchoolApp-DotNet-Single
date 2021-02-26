using CTS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace CTS.Business.AdminAPP.Interface
{
    public interface IAuditLogsManager
    {
        Task<Dictionary<string, dynamic>> GetAuditLogs(GridParameters pagingParameters);
        Task<Dictionary<string, dynamic>> AuditlogTableDetails(GridParameters pagingParameters);
    }
}
