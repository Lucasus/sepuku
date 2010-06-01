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
    public class KingdomTechnologyDAO : IDAO<KingdomTechnology>
    {
        public KingdomTechnology DataObject { get; set; }

        public int Add(KingdomTechnology o)
        {
            DataObject = o;
            return DAO<KingdomTechnologyDAO, KingdomTechnology>.Add("SepKingdomTechnologyAdd", this);
        }

        public void FillParametersFromProperties(Database db, ref DbCommand cmd)
        {
            if (this.DataObject.KingdomTechnologyId > 0)
            {
                db.AddInParameter(cmd, "KingdomTechnologyId", DbType.Int32, this.DataObject.KingdomTechnologyId);
            }
            db.AddInParameter(cmd, "TechnologyId", DbType.Int32, this.DataObject.TechnologyId);
            db.AddInParameter(cmd, "KingdomId", DbType.Int32, this.DataObject.KingdomId);
        }

        public KingdomTechnology GetFromRow(DataRow dr)
        {
            KingdomTechnology obj = new KingdomTechnology();
            obj.KingdomTechnologyId = Helper.GetData<int>(dr, "KingdomTechnologyId");
            obj.KingdomId = Helper.GetData<int>(dr, "KingdomId");
            obj.TechnologyId = Helper.GetData<int>(dr, "TechnologyId");
            return obj;
        }

        public KingdomTechnology GetByKingdomAndTechnology(int kingdomId, int technologyId)
        {
            return DAO<KingdomTechnologyDAO, KingdomTechnology>.GetSingleObject("SepKingdomTechnologyGetByKingdomAndTechnology", kingdomId, technologyId);
        }
    }
}