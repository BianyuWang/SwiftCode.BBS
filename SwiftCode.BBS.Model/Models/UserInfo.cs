using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model.Models
{
    /// <summary>
    /// user information
    /// </summary>
   public class UserInfo : RootEntityTKey<int>
    {/// <summary>
    /// User Name
    /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Login Name
        /// </summary>
        public string LoginName { get; set; }
       /// <summary>
       /// Login password
       /// </summary>
        public string LoginPassword { get; set; }
       /// <summary>
       /// user phone number
       /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// presonnal introduction
        /// </summary>
        public string Introduction { get; set; }
       /// <summary>
       /// Email address
       /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// avatar image
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// time of create
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
