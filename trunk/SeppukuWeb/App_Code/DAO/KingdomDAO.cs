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
    public class KingdomDAO : IDAO<Kingdom>
    {
        public Kingdom DataObject { get; set; }

        public int Add(Kingdom o)
        {
            DataObject = o;
            return DAO<KingdomDAO, Kingdom>.Add("DnKingdomAdd", this);
        }

        public IList<Kingdom> GetByUserId(int userId)
        {
            return DAO<KingdomDAO, Kingdom>.GetObjectList("SepKingdomGetByUserId", userId);
        }

        public void FillParametersFromProperties(Database db, ref DbCommand cmd)
        {
            if (this.DataObject.KingdomId > 0)
            {
                db.AddInParameter(cmd, "KingdomId", DbType.Int32, this.DataObject.KingdomId);
            }
        }

        public Kingdom GetFromRow(DataRow dr)
        {
            Kingdom obj = new Kingdom();
            obj.KingdomId = Helper.GetData<int>(dr, "KingdomId");
            return obj;
        }
    }
}