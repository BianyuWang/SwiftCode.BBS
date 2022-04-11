using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model.Models.RootKey
{/// <summary>
/// Link model -- UserInfor and Article
/// </summary>
   public class UserCollectionArticle : RootEntityTKey<int>
    {/// <summary>
     /// foreign key -- UsereId from UserInfo
     /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// foreign key -- ArticleId from Article
        /// </summary>
        public int ArticleId { get; set; }
    }
}
