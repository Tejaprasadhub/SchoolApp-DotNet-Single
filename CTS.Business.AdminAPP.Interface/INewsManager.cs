using CTS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Business.AdminAPP.Interface
{
    public interface INewsManager
    {
        Task<Dictionary<string, dynamic>> GetNews(GridParameters pagingParameters);

        bool AEDNews(CrudModel input, int userid);
    }
}
