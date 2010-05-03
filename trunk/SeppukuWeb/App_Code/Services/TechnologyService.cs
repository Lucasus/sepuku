using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Seppuku.Core;
using Seppuku.DAO;
using Seppuku.Domain;

namespace Seppuku.Services
{
    public class TechnologyService
    {
        public int Add(Technology o)
        {
            return new TechnologyDAO().Add(o);
        }

        public IList<Technology> GetAll()
        {
            int kingdomId = CurrentUser.KingdomId;
            return new TechnologyDAO().GetByKingdomId(kingdomId);
        }
    }
}