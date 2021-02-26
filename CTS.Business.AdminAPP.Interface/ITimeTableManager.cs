using CTS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Business.AdminAPP.Interface
{
    public interface ITimeTableManager
    {
        Task<Dictionary<string, dynamic>> GetTimetable(GridParameters pagingParameters);
        bool AEDTimetable(CrudModel input, int userid);
    }
}
