using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seppuku.Domain
{
    public class KingdomTechnology
    {
        public int KingdomTechnologyId { get; set; }
        public int KingdomId { get; set; }
        public int TechnologyId { get; set; }
    }
}