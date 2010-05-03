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
    public class RoleDAO : IDAO<Role>
    {
        public Role DataObject { get; set; }

        public IList<Role> GetByUserId(int userId)
        {
            return DAO<RoleDAO, Role>.GetObjectList("DnRoleGetByUserId", userId);
        }

        public IList<Role> GetByUserName(string userName)
        {
            return DAO<RoleDAO, Role>.GetObjectList("DnRoleGetByUserName", userName);
        }

        public IList<Role> GetAll()
        {
            return DAO<RoleDAO, Role>.GetObjectList("DnRoleGetAll");
        }

        public void FillParametersFromProperties(Database db, ref DbCommand cmd)
        {
            throw new NotImplementedException();
        }

        public Role GetFromRow(DataRow dr)
        {
            Role obj = new Role();
            obj.RoleId = Helper.GetData<int>(dr, "RoleId");
            obj.RoleName = Helper.GetData<string>(dr, "RoleName");
            return obj;
        }
    }
}