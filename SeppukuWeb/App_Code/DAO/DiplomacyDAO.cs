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
    public class DiplomacyDAO : IDAO<Diplomacy>
    {
        public Diplomacy DataObject { get; set; }

        public int Add(Diplomacy o)
        {
            this.DataObject = o;
            return DAO<DiplomacyDAO, Diplomacy>.Add("SepDiplomacyAdd", this);
        }

        public void FillParametersFromProperties(Database db, ref DbCommand cmd)
        {
            if (this.DataObject.DiplomacyId > 0)
            {
                db.AddInParameter(cmd, "DiplomacyId", DbType.Int32, this.DataObject.DiplomacyId);
            }
            db.AddInParameter(cmd, "DiplomacyStatusId", DbType.Int32, this.DataObject.DiplomacyStatusId);
            db.AddInParameter(cmd, "MainUserId", DbType.Int32, this.DataObject.MainUserId);
            db.AddInParameter(cmd, "SecondaryUserId", DbType.Int32, this.DataObject.SecondaryUserId);
        }

        public Diplomacy GetFromRow(DataRow dr)
        {
            Diplomacy obj = new Diplomacy();
            obj.DiplomacyId = Helper.GetData<int>(dr, "DiplomacyId");
            obj.DiplomacyStatusId = Helper.GetData<int>(dr, "DiplomacyStatusId");
            obj.DiplomacyStatusName = Helper.GetData<string>(dr, "DiplomacyStatusName");
            obj.MainUserId = Helper.GetData<int>(dr, "MainUserId");
            obj.MainUserName = Helper.GetData<string>(dr, "MainUserName");
            obj.SecondaryUserId = Helper.GetData<int>(dr, "SecondaryUserId");
            obj.SecondaryUserName = Helper.GetData<string>(dr, "SecondaryUserName");
            return obj;
        }

        public Diplomacy GetById(int diplomacyId)
        {
            return DAO<DiplomacyDAO, Diplomacy>.GetSingleObject("SepDiplomacyGetById", diplomacyId);
        }

        public IList<Diplomacy> GetByUserId(int userId)
        {
            return DAO<DiplomacyDAO, Diplomacy>.GetObjectList("SepDiplomacyGetByUserId", userId);
        }
    }
}