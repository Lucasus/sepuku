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

        public List<Message> GetBoxByUserId(int userId)
        {
            return DAO<MessageDAO, Message>.GetObjectList("DnMessageGetByUserId", userId);
        }

        public List<Message> GetChatWithUserId(int currentuserId, int userId)
        {
            return DAO<MessageDAO, Message>.GetObjectList("DnMessageChatByUserIdWithUserId",currentuserId, userId);
        }
        

        public void FillParametersFromProperties(Database db, ref DbCommand cmd)
        {
            if (this.DataObject.MessageId > 0)
            {
                db.AddInParameter(cmd, "MessageId", DbType.Int32, this.DataObject.MessageId);
            }
            db.AddInParameter(cmd, "MainUserId", DbType.Int32, this.DataObject.MainUserId);
            db.AddInParameter(cmd, "SecondaryUserId", DbType.Int32, this.DataObject.SecondaryUserId);
            db.AddInParameter(cmd, "Title", DbType.String, this.DataObject.Title);
            db.AddInParameter(cmd, "Text", DbType.String, this.DataObject.Text);
        }

        public Message GetFromRow(DataRow dr)
        {
            Message obj = new Message();
            obj.MessageId = Helper.GetData<int>(dr, "MessageId");
            obj.MainUserId = Helper.GetData<int>(dr, "MainUserId");
            obj.MainUserName = Helper.GetData<string>(dr, "MainUserName");
            obj.SecondaryUserId = Helper.GetData<int>(dr, "SecondaryUserId");
            obj.SecondaryUserName = Helper.GetData<string>(dr, "SecondaryUserName");
            obj.Title = Helper.GetData<string>(dr, "Title");
            obj.Text = Helper.GetData<string>(dr, "Text");
            obj.SendDate = Helper.GetData<DateTime>(dr, "SendDate");
            obj.isRead = Helper.GetData<bool>(dr, "isRead");
            return obj;
        }
    }
}