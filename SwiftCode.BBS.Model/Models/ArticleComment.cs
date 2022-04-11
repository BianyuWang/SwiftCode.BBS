using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model.Models
{
    public class ArticleComment : RootEntityTKey<int>
    {
        /// <summary>
        /// content of comment
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// time of creation
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// foreign key --- create by userId
        /// </summary>
        public int CreateUserId { get; set; }
        /// <summary>
        /// who create this comment
        /// </summary>
        public virtual UserInfo CreateUser { get; set; }
        /// <summary>
        /// foreign key --- comment of article Id
        /// </summary>
        public int ArticleId { get; set; }
        /// <summary>
        /// which article is this comment for
        /// </summary>
        public virtual Article Article { get; set; }


    }
}
