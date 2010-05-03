using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seppuku.Domain
{
    public class Field
    {
        public int FieldId { get; set; }
        public int MapId { get; set; }
        public int KingdomId { get; set; }
        public string FieldName { get; set; }
        public int FieldX { get; set; }
        public int FieldY { get; set; }
    }
}