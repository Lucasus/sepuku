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
            return DAO<KingdomDAO, Kingdom>.Add("SepKingdomAdd", this);
        }

        public Kingdom GetByUserId(int userId)
        {
            return DAO<KingdomDAO, Kingdom>.GetSingleObject("SepKingdomGetByUserId", userId);
        }

        public void FillParametersFromProperties(Database db, ref DbCommand cmd)
        {
            if (this.DataObject.KingdomId > 0)
            {
                db.AddInParameter(cmd, "KingdomId", DbType.Int32, this.DataObject.KingdomId);
            }
            db.AddInParameter(cmd, "KingdomName", DbType.String, this.DataObject.KingdomName);
            db.AddInParameter(cmd, "KingdomResources", DbType.Int32, this.DataObject.KingdomResources);
            db.AddInParameter(cmd, "MapId", DbType.Int32, this.DataObject.MapId);
            db.AddInParameter(cmd, "UserId", DbType.Int32, this.DataObject.UserId);
        }

        public Kingdom GetFromRow(DataRow dr)
        {
            Kingdom obj = new Kingdom();
            obj.KingdomId = Helper.GetData<int>(dr, "KingdomId");
            obj.KingdomName = Helper.GetData<string>(dr, "KingdomName");
            obj.KingdomResources = Helper.GetData<int>(dr, "KingdomResources");
            obj.UserId = Helper.GetData<int>(dr, "UserId");
            obj.MapId = Helper.GetData<int>(dr, "MapId");
            obj.KingdomArmy = Helper.GetData<int>(dr, "KingdomArmy");
            obj.KingdomSize = Helper.GetData<int>(dr, "KingdomSize");
            return obj;
        }

        public void Update(Kingdom k)
        {
            DataObject = k;
            DAO<KingdomDAO, Kingdom>.Add("SepKingdomUpdate", this);
        }

        public Kingdom GetInfoById(int kingdomId)
        {
            return DAO<KingdomDAO, Kingdom>.GetSingleObject("SepKingdomGetInfoById", kingdomId);
        }
    }
}