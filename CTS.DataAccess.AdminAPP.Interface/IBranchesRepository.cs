using CTS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.AdminAPP.Interface
{
    public interface IBranchesRepository
    {
        DataSet GetBranches(GridParameters pagingParameters);
        bool AEDBranches(CrudModel input,int userid);
    }
}
