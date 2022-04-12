using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model.ViewModels.UserInfo
{/// <summary>
/// which field can be updated
/// </summary>
    public  class UpdateUserInfoInputDto
    {
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
        public string Avator { get; set; }
    }
}
