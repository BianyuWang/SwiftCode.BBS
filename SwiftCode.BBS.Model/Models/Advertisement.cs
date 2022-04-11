using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model.Models
{
    /// <summary>
    /// ad 
    /// </summary>
    public class Advertisement : RootEntityTKey<int>
    {
        /// <summary>
        /// image of advertise
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        /// url
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// time of creation
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
