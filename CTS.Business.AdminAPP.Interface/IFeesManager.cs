using CTS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Business.AdminAPP.Interface
{
    public interface IFeesManager
    {
        Task<Dictionary<string, dynamic>> GetFees(GridParameters pagingParameters);
    }
}
