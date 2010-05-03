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
    public class MapDAO : IDAO<Map>
    {
        public Map DataObject { get; set; }

        public int Add(Map o)
        {
            DataObject = o;
            return DAO<MapDAO, Map>.Add("DnMapAdd", this);
        }

        public IList<Map> GetByUserId(int userId)
        {
            return DAO<MapDAO, Map>.GetObjectList("SepMapGetByUserId", userId);
        }

        public void FillParametersFromProperties(Database db, ref DbCommand cmd)
        {
            if (this.DataObject.MapId > 0)
            {
                db.AddInParameter(cmd, "MapId", DbType.Int32, this.DataObject.MapId);
            }
        }

        public Map GetFromRow(DataRow dr)
        {
            Map obj = new Map();
            obj.MapId = Helper.GetData<int>(dr, "MapId");
            return obj;
        }
    }
}