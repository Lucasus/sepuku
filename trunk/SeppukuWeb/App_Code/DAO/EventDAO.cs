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
    public class EventDAO : IDAO<Event>
    {
        public Event DataObject { get; set; }

        public int Add(Event o)
        {
            DataObject = o;
            return DAO<EventDAO, Event>.Add("DnEventAdd", this);
        }

        public IList<Event> GetByUserId(int userId)
        {
            return DAO<EventDAO, Event>.GetObjectList("SepEventGetByUserId", userId);
        }

        public void FillParametersFromProperties(Database db, ref DbCommand cmd)
        {
            if (this.DataObject.EventId > 0)
            {
                db.AddInParameter(cmd, "EventId", DbType.Int32, this.DataObject.EventId);
            }
        }

        public Event GetFromRow(DataRow dr)
        {
            Event obj = new Event();
            obj.EventId = Helper.GetData<int>(dr, "EventId");
            return obj;
        }
    }
}