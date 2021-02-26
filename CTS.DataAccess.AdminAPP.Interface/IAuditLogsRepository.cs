using CTS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.AdminAPP.Interface
{
    public interface IAuditLogsRepository
    {
        DataSet GetAuditLogs();

        DataSet AuditlogTableDetails(GridParameters pagingParameters);

    }
}
