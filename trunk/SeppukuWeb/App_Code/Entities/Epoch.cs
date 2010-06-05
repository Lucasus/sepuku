using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;




namespace Seppuku.Domain
{
    public class Epoch
    {
        public int EpochId { get; set; }
        public int MapId { get; set; }
        public DateTime EpochStart { get; set; }
    }
}
