using CTS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.AdminAPP.Interface
{
    public interface ITimetableRepository
    {
        DataSet GetTimetable(GridParameters pagingParameters);
        bool AEDTimetable(CrudModel input, int userid);
    }
}
