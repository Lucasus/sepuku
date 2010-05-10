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
    public class LogDAO : IDAO<Log>
    {
        public Log DataObject { get; set; }

        public int Add(Log o)
        {
            DataObject = o;
            return DAO<LogDAO, Log>.Add("DnLogAdd", this);
        }

        public void FillParametersFromProperties(Database db, ref DbCommand cmd)
        {
            if (this.DataObject.LogId > 0)
            {
                db.AddInParameter(cmd, "LogId", DbType.Int32, this.DataObject.LogId);
            }
        }

        public Log GetFromRow(DataRow dr)
        {
            Log obj = new Log();
            obj.LogId = Helper.GetData<int>(dr, "LogId");
            return obj;
        }
    }
}