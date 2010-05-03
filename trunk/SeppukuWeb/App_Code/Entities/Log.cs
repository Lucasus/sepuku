using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seppuku.Domain
{
    public class Log
    {
        public int LogId { get; set; }
        public DateTime LogTime { get; set; }
        public int LogTimeCounter { get; set; }
    }
}