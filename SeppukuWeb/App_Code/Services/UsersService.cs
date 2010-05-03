using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Seppuku.Core;
using Seppuku.DAO;

namespace Seppuku.Services
{
    public class UsersService
    {
        public bool AuthorizeUser(string userName, string authorizationKey, CommandStatus status)
        {
            return new UserDAO().Authorize(userName, authorizationKey, status);
        }
    }
}