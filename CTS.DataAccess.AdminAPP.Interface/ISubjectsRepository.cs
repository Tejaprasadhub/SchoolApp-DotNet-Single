using CTS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.AdminAPP.Interface
{
    public interface ISubjectsRepository
    {
        DataSet GetSubjects(GridParameters pagingParameters);
        bool AEDSubjects(CrudModel input, int userid);
    }
}
