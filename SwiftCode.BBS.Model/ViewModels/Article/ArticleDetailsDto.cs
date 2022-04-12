using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftCode.BBS.Model.ViewModels.UserInfo;

namespace SwiftCode.BBS.Model.ViewModels.Article
{/// <summary>
/// article details 
/// </summary>
    public class ArticleDetailsDto
    {
        /// <summary>
        /// title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// cover
        /// </summary>
        public string Cover { get; set; }
        /// <summary>
        /// content
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// category
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// count of traffic
        /// </summary>
        public int Traffic { get; set; }
        /// <summary>
        /// create time
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// by user id
        /// </summary>
        public int CreateUserId { get; set; }
 
        /// <summary>
        /// list of comments
        /// </summary>
        public List<ArticleCommentDto> ArticleComments { get; set; }



    }
}
