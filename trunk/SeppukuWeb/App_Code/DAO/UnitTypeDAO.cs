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
    public class UnitTypeDAO : IDAO<UnitType>
    {
        public UnitType DataObject { get; set; }

        public int Add(UnitType o)
        {
            DataObject = o;
            return DAO<UnitTypeDAO, UnitType>.Add("DnUnitTypeAdd", this);
        }

        public IList<UnitType> GetByUserId(int userId)
        {
            return DAO<UnitTypeDAO, UnitType>.GetObjectList("SepUnitTypeGetByUserId", userId);
        }

        public IList<UnitType> GetAll()
        {
            return DAO<UnitTypeDAO, UnitType>.GetObjectList("SepUnitTypeGetAll");
        }

        public void FillParametersFromProperties(Database db, ref DbCommand cmd)
        {
            if (this.DataObject.UnitTypeId > 0)
            {
                db.AddInParameter(cmd, "UnitTypeId", DbType.Int32, this.DataObject.UnitTypeId);
            }
        }

        public UnitType GetFromRow(DataRow dr)
        {
            UnitType obj = new UnitType();
            obj.UnitTypeId = Helper.GetData<int>(dr, "UnitTypeId");
            obj.UnitTypeName = Helper.GetData<string>(dr, "UnitTypeName");
            obj.UnitTypeDescription = Helper.GetData<string>(dr, "UnitTypeDescription");
            obj.UnitTypePower = Helper.GetData<int>(dr, "UnitTypePower");
            obj.UnitTypeHealthPoint = Helper.GetData<int>(dr, "UnitTypeHealthPoint");
            return obj;
        }

        internal UnitType GetById(int unitTypeId)
        {
            return DAO<UnitTypeDAO, UnitType>.GetSingleObject("SepUnitTypeGetById", unitTypeId);
        }
    }
}