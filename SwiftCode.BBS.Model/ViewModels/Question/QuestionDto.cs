using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftCode.BBS.Model.Models;


namespace SwiftCode.BBS.Model.ViewModels.Question
{/// <summary>
/// question view model
/// </summary>
    public class QuestionDto : RootEntityTKey<int>
    {

        /// <summary>
        /// title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// category
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// create time
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// who create this question
        /// </summary>
        public int CreateUserId { get; set; }

        /// <summary>
        /// count of comments
        /// </summary>
        public int QuestionCommentCount { get; set; }

    }
}
