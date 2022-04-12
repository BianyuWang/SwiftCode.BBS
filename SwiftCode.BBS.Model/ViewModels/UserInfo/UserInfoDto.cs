using SwiftCode.BBS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model.ViewModels.UserInfo
{/// <summary>
/// User article related DTO
/// </summary>
  public class UserInfoDto : RootEntityTKey<int>
    {/// <summary>
    /// user
    /// </summary>
        public string UserName { get; set; }
     /// <summary>
     /// image
     /// </summary>
        public string Avatar { get; set; }
      /// <summary>
      /// how many articles under this user
      /// </summary>
        public long ArticleCount { get; set; }
     /// <summary>
     /// how many questions under this user
     /// </summary>
        public long QuestionCount { get; set; }
        
    }
}
