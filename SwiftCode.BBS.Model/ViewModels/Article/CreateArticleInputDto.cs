using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model.ViewModels.Article
{/// <summary>
/// create article
/// </summary>
    public class CreateArticleInputDto
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
        /// categoru
        /// </summary>
        public string Tag { get; set; }
    }
}
