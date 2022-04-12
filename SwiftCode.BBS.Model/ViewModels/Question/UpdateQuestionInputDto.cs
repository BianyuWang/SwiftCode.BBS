using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model.ViewModels.Question
{/// <summary>
/// update question view model
/// </summary>
    public class UpdateQuestionInputDto
    {
        /// <summary>
        /// title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// content
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// category
        /// </summary>
        public string Tag { get; set; }
    }
}
