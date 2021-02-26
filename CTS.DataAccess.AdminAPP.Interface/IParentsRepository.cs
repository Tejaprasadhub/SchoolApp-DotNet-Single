using CTS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.AdminAPP.Interface
{
    public interface IParentsRepository
    {
        DataSet GetParents(GridParameters pagingParameters);
        bool AEDParents(CrudModel input, int userid);
    }
}
