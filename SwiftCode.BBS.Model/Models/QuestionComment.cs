using System;

namespace SwiftCode.BBS.Model.Models
{/// <summary>
/// question comment
/// </summary>
    public class QuestionComment : RootEntityTKey<int>
    {
        /// <summary>
        /// content
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// time of creation
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// is adopte by create
        /// </summary>
        public bool IsAdoption { get; set; }
        /// <summary>
        /// id of who create this comment
        /// </summary>
        public int CreateUserId { get; set; }
        /// <summary>
        /// who create this comment
        /// </summary>
        public virtual UserInfo CreateUser { get; set; }


        /// <summary>
        /// the comment is for which question (id)
        /// </summary>
        public int QuestionId { get; set; }
        /// <summary>
        /// the comment is for which question 
        /// </summary>
        public virtual Question Question { get; set; }
    }
}