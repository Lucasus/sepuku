using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seppuku.Domain
{
    public class UnitType
    {
        public int UnitTypeId { get; set; }
        public string UnitTypeName { get; set; }
        public string UnitTypeDescription { get; set; }
        public int UnitTypePower { get; set; }
        public int UnitTypeHealthPoint { get; set; }
        public int UnitTypeCost { get; set; }
    }
}