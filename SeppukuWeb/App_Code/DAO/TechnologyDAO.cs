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
    public class TechnologyDAO : IDAO<Technology>
    {
        public Technology DataObject { get; set; }

        public int Add(Technology o)
        {
            DataObject = o;
            return DAO<TechnologyDAO, Technology>.Add("DnTechnologyAdd", this);
        }

        public IList<Technology> GetByUserId(int userId)
        {
            return DAO<TechnologyDAO, Technology>.GetObjectList("SepTechnologyGetByUserId", userId);
        }

        public void FillParametersFromProperties(Database db, ref DbCommand cmd)
        {
            if (this.DataObject.TechnologyId > 0)
            {
                db.AddInParameter(cmd, "TechnologyId", DbType.Int32, this.DataObject.TechnologyId);
            }
        }

        public Technology GetFromRow(DataRow dr)
        {
            Technology obj = new Technology();
            obj.TechnologyId = Helper.GetData<int>(dr, "TechnologyId");
            return obj;
        }
    }
}