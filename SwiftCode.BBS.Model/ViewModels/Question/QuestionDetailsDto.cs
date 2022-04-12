using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftCode.BBS.Model.ViewModels.UserInfo;

namespace SwiftCode.BBS.Model.ViewModels.Question
{/// <summary>
/// question details
/// </summary>
    public class QuestionDetailsDto
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
        /// count of comments
        /// </summary>
        public int QuestionCommentCount { get; set; }

        /// <summary>
        /// create time
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// list of comments
        /// </summary>
        public virtual List<QuestionCommentDto> QuestionComments { get; set; }
    }
}
