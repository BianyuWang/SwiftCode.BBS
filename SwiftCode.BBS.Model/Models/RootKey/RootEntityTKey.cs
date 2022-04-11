using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Model.Models
{/// <summary>
 /// Generics class
 /// </summary>
 /// <typeparam name="Tkey"></typeparam>
    public class RootEntityTKey<Tkey> where Tkey : IEquatable<Tkey>
    {/// <summary>
    /// id -- primary key of Generics class
    /// </summary>
        public Tkey Id { get; set; }
    }
}
