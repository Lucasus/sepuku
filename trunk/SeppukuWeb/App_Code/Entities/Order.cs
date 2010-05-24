using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seppuku.Domain
{
    public class Order
    {
        public int OrderId { get; set; }
        public int OrderTypeId { get; set; }
        public string OrderTypeName { get; set; }
        public int FieldId { get; set; }
        public int FieldIdDestination { get; set; }
        public DateTime OrderTime { get; set; }
        public int Epoch { get; set; }
    }
}