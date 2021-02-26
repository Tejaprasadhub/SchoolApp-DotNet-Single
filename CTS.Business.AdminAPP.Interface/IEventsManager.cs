using CTS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Business.AdminAPP.Interface
{
    public interface IEventsManager
    {
        Task<Dictionary<string, dynamic>> GetEvents(GridParameters pagingParameters);
        bool AEDEvents(CrudModel input, int userid);
    }
}
