using CTS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Business.AdminAPP.Interface
{
    public interface IParentsManager
    {
        Task<Dictionary<string, dynamic>> GetParents(GridParameters pagingParameters);
        bool AEDParents(CrudModel input, int userid);
    }
}
