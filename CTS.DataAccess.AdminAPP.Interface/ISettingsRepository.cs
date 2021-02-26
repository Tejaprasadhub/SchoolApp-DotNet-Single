using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace CTS.DataAccess.AdminAPP.Interface
{
    public interface ISettingsRepository
    {
        DataSet GetSettings();
    }
}
