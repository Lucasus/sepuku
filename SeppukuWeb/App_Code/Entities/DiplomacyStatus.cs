using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seppuku.Domain
{

    // Tabela słownikowa statnów w dyplomatycznych(np. (0,nie_napotkany), (1,wojna), (2,patk_o_nieagresji) itp.)

    public class DiplomacyStatus
    {
        public int DiplomacyStatusId { get; set; }
        public string DiplomacyStatusName { get; set; }
    }
}