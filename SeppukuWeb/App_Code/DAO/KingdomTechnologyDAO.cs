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
            return DAO<KingdomTechnologyDAO, KingdomTechnology>.Add("DnKingdomTechnologyAdd", this);
        }

        public IList<KingdomTechnology> GetByUserId(int userId)
        {
            return DAO<KingdomTechnologyDAO, KingdomTechnology>.GetObjectList("SepKingdomTechnologyGetByUserId", userId);
        }

        public void FillParametersFromProperties(Database db, ref DbCommand cmd)
        {
            if (this.DataObject.KingdomTechnologyId > 0)
            {
                db.AddInParameter(cmd, "KingdomTechnologyId", DbType.Int32, this.DataObject.KingdomTechnologyId);
            }
        }

        public KingdomTechnology GetFromRow(DataRow dr)
        {
            KingdomTechnology obj = new KingdomTechnology();
            obj.KingdomTechnologyId = Helper.GetData<int>(dr, "KingdomTechnologyId");
            return obj;
        }
    }
}