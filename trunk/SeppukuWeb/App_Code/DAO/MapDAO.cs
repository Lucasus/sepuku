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
    public class MapDAO : IDAO<Map>
    {
        public Map DataObject { get; set; }

        public int Add(Map o)
        {
            DataObject = o;
            return DAO<MapDAO, Map>.Add("SepMapAdd", this);
        }

        public void Update(Map o)
        {
            DataObject = o;
            DAO<MapDAO, Map>.Update("SepMapUpdate", this);
        }

        public void Delete(int mapId)
        {
            DAO<MapDAO, Map>.ExecuteNonQuery("SepMapDelete", mapId);
        }

        public IList<Map> GetByUserId(int userId)
        {
            return DAO<MapDAO, Map>.GetObjectList("SepMapGetByUserId", userId);
        }

        public Map GetById(int mapId)
        {
            return DAO<MapDAO, Map>.GetSingleObject("SepMapGetById", mapId);
        }

        public IList<Map> GetAll()
        {
            return DAO<MapDAO, Map>.GetObjectList("SepMapGetAll");
        }

        public void FillParametersFromProperties(Database db, ref DbCommand cmd)
        {
            if (this.DataObject.MapId > 0)
            {
                db.AddInParameter(cmd, "MapId", DbType.Int32, this.DataObject.MapId);
            }
            db.AddInParameter(cmd, "MapName", DbType.String, this.DataObject.MapName);
        }

        public Map GetFromRow(DataRow dr)
        {
            Map obj = new Map();
            obj.MapId = Helper.GetData<int>(dr, "MapId");
            obj.MapName = Helper.GetData<string>(dr, "MapName");
            return obj;
        }

    }
}