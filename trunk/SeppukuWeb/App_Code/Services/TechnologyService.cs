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

        public Technology GetById(int technologyId)
        {
            return new TechnologyDAO().GetById(technologyId);
        }


        public void Buy(int kingdomId, int technologyId)
        {
            KingdomTechnology kt = new KingdomTechnology()
            {
                 KingdomId = kingdomId,
                 TechnologyId = technologyId
            };
            KingdomTechnology old = new KingdomTechnologyDAO().GetByKingdomAndTechnology(kingdomId, technologyId);

            if(old.KingdomTechnologyId == 0)
            {
                new KingdomTechnologyDAO().Add(kt);
                Kingdom k = new KingdomDAO().GetByUserId(CurrentUser.UserId);
                Technology t = new TechnologyDAO().GetById(technologyId);
                k.KingdomResources -= t.TechnologyCost;
                new KingdomDAO().Update(k);
            }
        }
    }
}