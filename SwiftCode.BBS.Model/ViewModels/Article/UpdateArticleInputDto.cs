using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SwiftCode.BBS.Model.ViewModels.Article
{/// <summary>
/// update a article
/// </summary>
    public class UpdateArticleInputDto
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
        /// teg
        /// </summary>
        public string Tag { get; set; }
    }
}
