using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftCode.BBS.Model.Models;


namespace SwiftCode.BBS.Model.ViewModels.Article
{/// <summary>
/// article comment view model
/// </summary>
    public class ArticleCommentDto : RootEntityTKey<int>
    {
        /// <summary>
        /// content
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// create time
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// who create this article
        /// </summary>
        public int CreateUserId { get; set; }

        /// <summary>
        /// user name
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// image
        /// </summary>
        public string Avatar { get; set; }
    }
}
