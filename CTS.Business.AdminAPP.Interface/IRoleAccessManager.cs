using CTS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Business.AdminAPP.Interface
{
    public interface IRoleAccessManager
    {
        Task<Dictionary<string, dynamic>> GetRoleAccess(GridParameters pagingParameters);

        DataSet GetUserFeatures(string userid);
        DataSet GetSchoolFeatures();

        bool AEDRoleAccess(RoleAccessData input, string userid);
    }
}
