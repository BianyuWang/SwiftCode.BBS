using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model.ViewModels.UserInfo
{/// <summary>
/// User information related dto
/// </summary>
    public class UserInfoDetailsDto
    {
        /// <summary>
        /// user name
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// phone number
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// personal summary
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// image
        /// </summary>
        public string Avatar { get; set; }
    }
}
