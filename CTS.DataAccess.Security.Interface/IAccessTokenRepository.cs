using CTS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.Security.Interface
{
    public interface IAccessTokenRepository
    {
        DataSet GetSchoolUserDetailsBasedOnSubdomain();  
        DataSet ValidateUser(AuthenticationCredintials login);
       
    }
}
