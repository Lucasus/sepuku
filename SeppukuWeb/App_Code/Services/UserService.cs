using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Seppuku.Core;
using Seppuku.DAO;
using Seppuku.Domain;

namespace Seppuku.Services
{
    public class UserService
    {
        public bool AuthorizeUser(string userName, string authorizationKey, CommandStatus status)
        {
            return new UserDAO().Authorize(userName, authorizationKey, status);
        }

        public User GetByEmail(string email)
        {
            return new UserDAO().GetByUserEmail(email);
        }

        public User GetByLogin(string login)
        {
            return new UserDAO().GetByUserName(login, null);
        }

        public IList<User> GetAll()
        {
            return new UserDAO().GetAll();
        }

        public int NewChangePasswordKey(int userId, Guid key)
        {
            return new UserDAO().AddChangePasswordKey(userId, key);
        }

        public void ChangePasswordWithKey(string key, string password)
        {
            new UserDAO().ChangePasswordWithKey(key, DNMembershipProvider.CreatePasswordHash(password));
        }

        public bool ValidateChangePasswordKey(string changePasswordKey)
        {
            return new UserDAO().ValidateChangePasswordKey(changePasswordKey);
        }

        public void Update(User user)
        {
            user.CreateDate = new DateTime();
            user.AuthorizatonKey = Guid.Empty;
            new UserDAO().Update(user);
        }
    }
}