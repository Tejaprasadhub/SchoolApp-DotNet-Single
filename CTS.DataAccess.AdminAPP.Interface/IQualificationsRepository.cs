using CTS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.AdminAPP.Interface
{
    public interface IQualificationsRepository
    {
        DataSet GetQualifications(GridParameters pagingParameters);
        bool AEDQualifications(CrudModel input, int userid);
    }
}
