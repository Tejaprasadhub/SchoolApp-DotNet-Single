using CTS.Common;
using CTS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Business.AdminAPP.Interface
{
    public interface IUsersManager
    {
        Task<Dictionary<string, dynamic>> GetUsers(GridParameters pagingParameters);
        bool AEDUsers(CrudModel input, string userid);

        AuthorizationResult AuthorizeComponentAccess(string routeUrl, string userid);
        DataTable permissionsOnComponent(string routeUrl, string userid);
    }
}
