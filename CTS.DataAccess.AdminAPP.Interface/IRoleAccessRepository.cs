using CTS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.AdminAPP.Interface
{
    public interface IRoleAccessRepository
    {
        DataSet GetRoleAccess();

        DataSet GetUserFeatures(string userid);
        DataSet GetSchoolFeatures();

        bool AEDRoleAccess(RoleAccessData input, string userid);
    }
}
