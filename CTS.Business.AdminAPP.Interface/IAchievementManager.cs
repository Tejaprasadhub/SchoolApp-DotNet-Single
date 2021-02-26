using CTS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Business.AdminAPP.Interface
{
    public interface IAchievementManager
    {
        Task<Dictionary<string, dynamic>> GetAchievement(GridParameters pagingParameters);
        bool AEDAchievements(CrudModel input, int userid);
    }
}
