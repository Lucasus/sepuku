using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seppuku.Domain
{
    public class Event
    {
        public int EventId { get; set; }
        public int LogId { get; set; }
        public int KingdomId { get; set; }
        public string EventDescription { get; set; }
    }
}