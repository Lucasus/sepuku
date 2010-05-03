using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seppuku.Domain
{
    public class Technology
    {
        public int TechnologyId { get; set; }
        public string TechnologyName { get; set; }
        public string TechnologyDescription { get; set; }
        public string TechnologyEffect { get; set; }
        public int TechnologyCost { get; set; }
    }
}