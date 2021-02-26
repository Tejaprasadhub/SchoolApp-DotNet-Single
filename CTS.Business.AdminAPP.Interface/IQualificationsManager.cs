using CTS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Business.AdminAPP.Interface
{
    public interface IQualificationsManager
    {
        Task<Dictionary<string, dynamic>> GetQualifications(GridParameters pagingParameters);
        bool AEDQualifications(CrudModel input, int userid);
    }
}
