using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;




namespace Seppuku.Domain
{
    public class Diplomacy
    {     
        public int DiplomacyId { get; set; }
        public int DiplomacyStatusId { get; set; }
        public int MainUserId { get; set; }
        public int SecondaryUserId { get; set; }
     
    }
}