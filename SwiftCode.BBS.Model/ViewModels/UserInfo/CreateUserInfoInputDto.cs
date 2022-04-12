using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model.ViewModels.UserInfo
{/// <summary>
/// Dto used for creating a new user
/// </summary>
    public class CreateUserInfoInputDto
    {
        /// <summary>
        /// user name
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// login name
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// password
        /// </summary>
        public string LoginPassWord { get; set; }
        /// <summary>
        /// phone number
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// summary
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// image
        /// </summary>
        public string Avator { get; set; }

    }
}
