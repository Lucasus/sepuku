using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seppuku.Domain
{
    public class Unit
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int UnitTypeId { get; set; }
        public int KingdomId { get; set; }
        public int FieldId { get; set; }
        public int Count { get; set; }
    }
}