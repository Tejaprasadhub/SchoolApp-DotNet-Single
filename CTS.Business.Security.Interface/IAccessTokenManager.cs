using CTS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.Business.Security.Interface
{
    public interface IAccessTokenManager
    {
        DataSet GetSchoolUserDetailsBasedOnSubdomain();
        DataSet ValidateUser(AuthenticationCredintials login);       

       
    }
}
