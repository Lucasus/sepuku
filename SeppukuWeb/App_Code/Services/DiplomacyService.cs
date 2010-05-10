using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Seppuku.Core;
using Seppuku.DAO;
using Seppuku.Domain;

namespace Seppuku.Services
{
    public class DiplomacyService
    {
        public int Add(Diplomacy o)
        {
            return new DiplomacyDAO().Add(o);
        }

        public IList<Diplomacy> GetUserDiplomacy()
        {
            int userId = CurrentUser.UserId;
            return new DiplomacyDAO().GetByUserId(userId);     
        }

        public Diplomacy GetById(int diplomacyId)
        {
            return new DiplomacyDAO().GetById(diplomacyId);
        }
    }
}