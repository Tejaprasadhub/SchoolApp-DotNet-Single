using CTS.Business.Security.Interface;
using CTS.Common;
using CTS.DataAccess.Security.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.Business.Security
{
   
   public class AccessTokenManager : IAccessTokenManager
    {
       // private readonly IConfiguration _config;
        private readonly IAccessTokenRepository _accessTokenRepository;
        public AccessTokenManager(IAccessTokenRepository accessTokenRepository)
        {
            // _config = config;
            _accessTokenRepository = accessTokenRepository;
        }
        public DataSet GetSchoolUserDetailsBasedOnSubdomain()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = _accessTokenRepository.GetSchoolUserDetailsBasedOnSubdomain();

                return ds;

            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ValidateUser(AuthenticationCredintials login)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = _accessTokenRepository.ValidateUser(login);

                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }      

      
    }
}
