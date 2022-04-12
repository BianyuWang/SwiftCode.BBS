using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model.ViewModels.Question
{/// <summary>
/// view model when create a question
/// </summary>
    public class CreateQuestionInputDto
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
