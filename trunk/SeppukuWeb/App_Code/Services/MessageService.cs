using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Seppuku.Core;
using Seppuku.DAO;
using Seppuku.Domain;

namespace Seppuku.Services
{
    public class MessageService
    {
        public int Add(Message o)
        {
            return new MessageDAO().Add(o);
        }

        public List<Message> GetUserInbox()
        {
            int userId = CurrentUser.UserId;
            return new MessageDAO().GetInboxByUserId(userId);
        }

        public List<Message> GetUserOutbox()
        {
            int userId = CurrentUser.UserId;
            return new MessageDAO().GetOutboxByUserId(userId);
        }
    }
}