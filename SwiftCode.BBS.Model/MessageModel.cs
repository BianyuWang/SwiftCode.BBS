using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model
{/// <summary>
/// general return messages
/// </summary>
  public class MessageModel<T>
    {
        /// <summary>
        /// status code
        /// </summary>
        public int status { get; set; } = 200;
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool success { get; set; } = false;
        /// <summary>
        /// return message
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 返回数据集合
        /// </summary>
        public T response { get; set; }


    }
}
