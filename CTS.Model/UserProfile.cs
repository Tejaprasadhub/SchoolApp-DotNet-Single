using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.Model
{
   public class UserProfile
    {
        public static UserProfile LoadFromJson(string json)
        {
            var result = JsonConvert.DeserializeObject<UserProfile>(json);
            return result;
        }
        public bool IsInternal { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserId { get; set; }
        public string UserDisplayName { get; set; }
        public string UserType { get; set; }
        public string UserStatus { get; set; }
        public string UserBranch { get; set; }
    }
}
