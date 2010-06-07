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
    public class EpochDAO : IDAO<Epoch>
    {
        public Epoch DataObject { get; set; }

        public void Add(int mapId)
        {
            DAO<EpochDAO, Epoch>.ExecuteNonQuery("SepNewEpochForMap", mapId);
        }

        public Epoch GetFromRow(DataRow dr)
        {
            Epoch obj = new Epoch();
            obj.EpochId = Helper.GetData<int>(dr, "EpochId");
            obj.MapId = Helper.GetData<int>(dr, "MapId");
            obj.EpochStart = Helper.GetData<DateTime>(dr, "EpochStart");
            
            return obj;
        }

        public void FillParametersFromProperties(Database db, ref DbCommand cmd)
        {
            if (this.DataObject.EpochId > 0)
            {
                db.AddInParameter(cmd, "EventId", DbType.Int32, this.DataObject.EpochId);
            }
        }

        public Epoch GetById(int epochId)
        {
            return DAO<EpochDAO, Epoch>.GetSingleObject("SepEpochGetById", epochId);
        }

        public Epoch GetCurrentByMapId(int mapId)
        {
            return DAO<EpochDAO, Epoch>.GetSingleObject("SepEpochGetCurrentByMapId", mapId);
        }
    }
}