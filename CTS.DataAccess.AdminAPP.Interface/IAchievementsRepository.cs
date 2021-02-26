using CTS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace CTS.DataAccess.AdminAPP.Interface
{
    public interface IAchievementsRepository
    {
         DataSet GetAchievement(GridParameters pagingParameters);
        bool AEDAchievements(CrudModel input, int userid);
    }
}
