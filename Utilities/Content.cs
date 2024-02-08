using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList
{
    internal abstract class AContent
    {
        internal virtual long ID { get; set; }
        internal virtual string name { get; set; }
        internal virtual int count { get; set; }
        internal virtual bool notOut { get; set; }
        internal virtual List<string> genres { get; set; }
        internal virtual string author { get; set; }
    }
}
