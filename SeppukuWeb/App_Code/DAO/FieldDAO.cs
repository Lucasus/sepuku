﻿using System;
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
            this.DataObject = o;
            return DAO<FieldDAO, Field>.Add("SepFieldAdd", this);
        }

        public Field GetByXY(int x, int y)
        {
            return DAO<FieldDAO, Field>.GetSingleObject("SepFieldGetByXY", x, y);
        }

        public Field GetById(int fieldId)
        {
            return DAO<FieldDAO, Field>.GetSingleObject("SepFieldGetById", fieldId);
        }

        public void FillParametersFromProperties(Database db, ref DbCommand cmd)
        {
            if (this.DataObject.FieldId > 0)
            {
                db.AddInParameter(cmd, "FieldId", DbType.Int32, this.DataObject.FieldId);
            }
            db.AddInParameter(cmd, "FieldName", DbType.String, this.DataObject.FieldName);
            db.AddInParameter(cmd, "FieldX", DbType.Int32, this.DataObject.FieldX);
            db.AddInParameter(cmd, "FieldY", DbType.Int32, this.DataObject.FieldY);
            if (this.DataObject.KingdomId > 0)
            {
                db.AddInParameter(cmd, "KingdomId", DbType.Int32, this.DataObject.KingdomId);
            }
            else
            {
                db.AddInParameter(cmd, "KingdomId", DbType.Int32, null);
            }
            
            db.AddInParameter(cmd, "MapId", DbType.Int32, this.DataObject.MapId);
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

        public IList<Field> GetByMapId(int MapId)
        {
            return DAO<FieldDAO, Field>.GetObjectList("SepFieldGetByMapId", MapId);
        }

        public void Update(Field f)
        {
            DataObject = f;
            DAO<FieldDAO, Field>.Update("SepFieldUpdate", this);
        }
    }
}