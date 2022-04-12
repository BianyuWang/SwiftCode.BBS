using SwiftCode.BBS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SwiftCode.BBS.Model.ViewModels.Question
{/// <summary>
/// question comment
/// </summary>
     public class QuestionCommentDto : RootEntityTKey<int>
    {
        /// <summary>
        ///content of comment
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// create time
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// if is adoptin by submitter of question
        /// </summary>
        public bool IsAdoption { get; set; }

        /// <summary>
        /// who created
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
