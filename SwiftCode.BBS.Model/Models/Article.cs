using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model.Models
{/// <summary>
/// artical on BBS
/// </summary>
  public  class Article
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// who create this artical
        /// </summary>
        public string Submitter { get; set; }
        /// <summary>
        /// title of this artical
        /// </summary>
        public string Title { get; set; }
       /// <summary>
       /// category
       /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// content
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// how many readers
        /// </summary>
        public int Traffic { get; set; }
        /// <summary>
        /// comment count 
        /// </summary>
        public int CommentNum { get; set; }
        /// <summary>
        /// last update time
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// create time
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// #marks
        /// </summary>
        public string Mark { get; set; }
        /// <summary>
        /// available to users
        /// </summary>
        public bool? IsDeleted { get; set; }
    }
}
