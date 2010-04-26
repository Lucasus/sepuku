using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DN.Core;
using DN.DAO;

namespace DN.Services
{
    public class UsersService
    {
        public bool AuthorizeUser(string userName, string authorizationKey, CommandStatus status)
        {
            return new UserDAO().Authorize(userName, authorizationKey, status);
        }
    }
}