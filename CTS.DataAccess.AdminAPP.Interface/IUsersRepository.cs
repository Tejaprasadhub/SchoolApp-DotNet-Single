using CTS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.AdminAPP.Interface
{
    public interface IUsersRepository
    {
        DataSet GetUsers(GridParameters pagingParameters);
        bool AEDUsers(CrudModel input, string userid);
        DataSet AuthorizeComponentAccess(string routeUrl, string userid);
        DataSet permissionsOnComponent(string routeUrl, string userid);
    }
}
