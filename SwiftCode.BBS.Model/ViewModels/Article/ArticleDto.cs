using SwiftCode.BBS.Model.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model.ViewModels.Article
{/// <summary>
/// article view model
/// </summary>
    public class ArticleDto: RootEntityTKey<int>
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
        /// create time
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// by user id
        /// </summary>
        public int CreateUserId { get; set; }


        /// <summary>
        /// by user name
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// image
        /// </summary>
        public string Avatar { get; set; }

    }
}
