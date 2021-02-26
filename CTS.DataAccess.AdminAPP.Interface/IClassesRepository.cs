using CTS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.AdminAPP.Interface
{
    public interface IClassesRepository
    {
        DataSet GetClasses(GridParameters pagingParameters);
        bool AEDClasses(CrudModel input, int userid);
    }
}
