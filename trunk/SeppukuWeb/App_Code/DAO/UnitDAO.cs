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
    public class UnitDAO : IDAO<Unit>
    {
        public Unit DataObject { get; set; }

        public int Add(Unit o)
        {
            DataObject = o;
            return DAO<UnitDAO, Unit>.Add("SepUnitAdd", this);
        }

        public void Update(Unit u)
        {
            DataObject = u;
            DAO<UnitDAO, Unit>.Add("SepUnitUpdate", this);
        }

        public void Remove(int unitId)
        {
            DAO<UnitDAO, Unit>.ExecuteNonQuery("SepUnitRemove", unitId);
        }

        public IList<Unit> GetByUserId(int userId)
        {
            return DAO<UnitDAO, Unit>.GetObjectList("SepUnitGetByUserId", userId);
        }

        public void FillParametersFromProperties(Database db, ref DbCommand cmd)
        {
            if (this.DataObject.UnitId > 0)
            {
                db.AddInParameter(cmd, "UnitId", DbType.Int32, this.DataObject.UnitId);
            }
            db.AddInParameter(cmd, "Count", DbType.Int32, this.DataObject.Count);
            db.AddInParameter(cmd, "FieldId", DbType.Int32, this.DataObject.FieldId);
            db.AddInParameter(cmd, "KingdomId", DbType.Int32, this.DataObject.KingdomId);
            db.AddInParameter(cmd, "UnitTypeId", DbType.Int32, this.DataObject.UnitTypeId);
            db.AddInParameter(cmd, "UnitName", DbType.String, this.DataObject.UnitName);
        }

        public Unit GetFromRow(DataRow dr)
        {
            Unit obj = new Unit();
            obj.UnitId = Helper.GetData<int>(dr, "UnitId");
            obj.Count = Helper.GetData<int>(dr, "Count");
            obj.FieldId = Helper.GetData<int>(dr, "FieldId");
            obj.KingdomId = Helper.GetData<int>(dr, "KingdomId");
            obj.UnitTypeId = Helper.GetData<int>(dr, "UnitTypeId");
            obj.UnitName = Helper.GetData<string>(dr, "UnitName");

            return obj;
        }

        public IList<Unit> GetFromArea(int mapId, int leftX, int TopY, int width, int height)
        {
            return DAO<UnitDAO, Unit>.GetObjectList("SepUnitGetFromArea", mapId, leftX, TopY,  width,  height);
        }
    }
}