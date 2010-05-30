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
    public class DiplomacyStatusDAO : IDAO<DiplomacyStatus>
    {
        public DiplomacyStatus DataObject { get; set; }

        public int Add(DiplomacyStatus o)
        {
            throw new NotImplementedException();
        }

        public DiplomacyStatus GetById(int id)
        {
            return DAO<DiplomacyStatusDAO, DiplomacyStatus>.GetSingleObject("SepDiplomacyStatusGetById", id);
        }

        public void FillParametersFromProperties(Database db, ref DbCommand cmd)
        {
            if (this.DataObject.DiplomacyStatusId > 0)
            {
                db.AddInParameter(cmd, "DiplomacyStatusId", DbType.Int32, this.DataObject.DiplomacyStatusId);
            }
        }

        public DiplomacyStatus GetFromRow(DataRow dr)
        {
            DiplomacyStatus obj = new DiplomacyStatus();
            obj.DiplomacyStatusId = Helper.GetData<int>(dr, "DiplomacyStatusId");
            return obj;
        }
    }
    
}