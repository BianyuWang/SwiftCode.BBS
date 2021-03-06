using SwiftCode.BBS.Model.Models.RootKey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model.Models
{/// <summary>
/// artical on BBS
/// </summary>
  public  class Article: RootEntityTKey<int>
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
        /// count of traffic4
        /// </summary>
        public int Traffic { get; set; }
        /// <summary>
        /// create time
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// create by user id
        /// </summary>
        public int CreateUserId { get; set; }
        /// <summary>
        /// create by user
        /// </summary>
        public virtual UserInfo CreateUser { get; set; }
        /// <summary>
        /// collected by user
        /// </summary>
        public virtual ICollection<UserCollectionArticle> CollectionArticles { get; set; } = new List<UserCollectionArticle>();
        /// <summary>
        /// commented by user
        /// </summary>
        public virtual ICollection<ArticleComment> ArticleComments { get; set; } = new List<ArticleComment>();

    }
}
