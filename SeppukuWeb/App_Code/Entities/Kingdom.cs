using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seppuku.Domain
{
    public class Kingdom
    {
        public int KingdomId { get; set; }
        public int MapId { get; set; }
        public int UserId { get; set; }
        public string KingdomName { get; set; }
        public int KingdomResources { get; set; }

        public int KingdomArmy { get; set; }
        public int KingdomSize { get; set; }
    }
}