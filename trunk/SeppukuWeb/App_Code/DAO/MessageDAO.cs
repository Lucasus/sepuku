using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Seppuku.Domain;
using Seppuku.Core;

namespace Seppuku.DAO
{
    public class MessageDAO : IDAO<Message>
    {
        public Message DataObject { get; set; }

        public int Add(Message o)
        {
            DataObject = o;
            return DAO<MessageDAO, Message>.Add("DnMessageAdd", this);
        }

        public List<Message> GetOutboxByUserId(int userId)
        {
            return DAO<MessageDAO, Message>.GetObjectList("DnMessageOutGetByUserId", userId);
        }

        public List<Message> GetInboxByUserId(int userId)
        {
            return DAO<MessageDAO, Message>.GetObjectList("DnMessageInGetByUserId", userId);
        }

        public void FillParametersFromProperties(Database db, ref DbCommand cmd)
        {
            if (this.DataObject.MessageId > 0)
            {
                db.AddInParameter(cmd, "MessageId", DbType.Int32, this.DataObject.MessageId);
            }
        }

        public Message GetFromRow(DataRow dr)
        {
            Message obj = new Message();
            obj.MessageId = Helper.GetData<int>(dr, "MessageId");
            return obj;
        }
    }
}