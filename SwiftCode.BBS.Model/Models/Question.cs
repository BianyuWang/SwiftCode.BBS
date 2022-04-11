using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model.Models
{/// <summary>
/// questions
/// </summary>
   public class Question : RootEntityTKey<int>
    {
        /// <summary>
        /// title pf question
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// content
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// tag,categorie of question
        /// </summary>
        public string Tag { get; set; }
       /// <summary>
       /// traffic of view
       /// </summary>
        public int Traffic { get; set; }
        /// <summary>
        /// time of creation
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// id of who create this question
        /// </summary>
        public int CreateUserId { get; set; }
        /// <summary>
        /// who create this question
        /// </summary>
        public virtual UserInfo CreateUser { get; set; }

        /// <summary>
        /// list of comments of this question
        /// </summary>
        public virtual ICollection<QuestionComment> QuestionComments { get; set; }

     
    }
}
