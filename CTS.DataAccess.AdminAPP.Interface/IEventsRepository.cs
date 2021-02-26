using CTS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.AdminAPP.Interface
{
    public interface IEventsRepository
    {
        DataSet GetEvents();
        bool AEDEvents(CrudModel input, int userid);
    }
}
