using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.AdminAPP.Interface
{
    public interface IDropdownRepository
    {
        DataSet GetDropdowns(string spName);
        DataSet GetMenuOptions();
    }
}
