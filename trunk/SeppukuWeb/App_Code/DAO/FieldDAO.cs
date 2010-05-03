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
    public class FieldDAO : IDAO<Field>
    {
        public Field DataObject { get; set; }

        public int Add(Field o)
        {
            DataObject = o;
            return DAO<FieldDAO, Field>.Add("DnFieldAdd", this);
        }

        public IList<Field> GetByUserId(int userId)
        {
            return DAO<FieldDAO, Field>.GetObjectList("SepFieldGetByUserId", userId);
        }

        public void FillParametersFromProperties(Database db, ref DbCommand cmd)
        {
            if (this.DataObject.FieldId > 0)
            {
                db.AddInParameter(cmd, "FieldId", DbType.Int32, this.DataObject.FieldId);
            }
        }

        public Field GetFromRow(DataRow dr)
        {
            Field obj = new Field();
            obj.FieldId = Helper.GetData<int>(dr, "FieldId");
            obj.FieldName = Helper.GetData<string>(dr, "FieldName");
            obj.FieldX = Helper.GetData<int>(dr, "FieldX");
            obj.FieldY = Helper.GetData<int>(dr, "FieldY");
            obj.KingdomId = Helper.GetData<int>(dr, "KingdomId");
            obj.MapId = Helper.GetData<int>(dr, "MapId");
            return obj;
        }
    }
}