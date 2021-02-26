using CTS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace CTS.Business.AdminAPP.Interface
{
    public interface ISettingsManager
    {
        Task<Dictionary<string, dynamic>> GetSettings(GridParameters pagingParameters);
    }
}
