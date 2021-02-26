using CTS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Business.AdminAPP.Interface
{
    public interface ISubjectsManager
    {
        Task<Dictionary<string, dynamic>> GetSubjects(GridParameters pagingParameters);
        bool AEDSubjects(CrudModel input, int userid);
    }
}
