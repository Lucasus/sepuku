using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Seppuku.Core;
using Seppuku.DAO;
using Seppuku.Domain;

namespace Seppuku.Services
{
    public class KingdomService
    {
        public int Add(Kingdom o)
        {
            return new KingdomDAO().Add(o);
        }

        public Kingdom GetUserKingdom()
        {
            int userId = CurrentUser.UserId;
            return new KingdomDAO().GetByUserId(userId);
        }
    }
}