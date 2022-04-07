using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Common.Helper
{/// <summary>
/// Token class
/// </summary>
  public  class TokenModelJWT
    {
        ///<summary>
        ///Id
        /// </summary>
        /// 
        public long Uid { get; set; }
        /// <summary>
        /// role
        /// </summary>
        public string Role { get; set; }
        ///<summary>
        ///职能
        /// </summary>
        public string Work { get; set; }

    }
}
