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
            return DAO<UnitDAO, Unit>.Add("DnUnitAdd", this);
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
        }

        public Unit GetFromRow(DataRow dr)
        {
            Unit obj = new Unit();
            obj.UnitId = Helper.GetData<int>(dr, "UnitId");
            return obj;
        }
    }
}