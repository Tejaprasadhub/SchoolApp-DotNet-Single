using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.Common
{
    public class AuthenticationCredintials
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserId { get; set; }
        public string UserType { get; set; }
        public string UserDisplayName { get; set; }
        public string UserStatus { get; set; }
        public string UserBranch { get; set; }
    }


    public class AuthorizationResult
    {
        public string status { get; set; }
        public List<string> featureOptions { get; set; }
    }
    //public enum DenialReason
    //{
    //    TwoFactorAuthenticationNotCompleted,
    //    PasswordUpdateRequired,
    //    NoMatchingComponentForUrl,
    //    UserDeniedAccessToUrl
    //}


   
}
