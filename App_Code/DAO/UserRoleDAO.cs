using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using DN.Domain;
using DN.Core;

namespace DN.DAO
{
    public class UserRoleDAO : IDAO<UserRole>
    {
        public UserRole DataObject { get; set; }

        public void FillParametersFromProperties(Database db, ref DbCommand cmd)
        {
            throw new NotImplementedException();
        }

        public UserRole GetFromRow(DataRow dr)
        {
            throw new NotImplementedException();
        }

        public void AddFromNames(string username, string rolename)
        {
            DAO<UserRoleDAO, UserRole>.ExecuteNonQuery("DnUserRoleAdd", username, rolename);
        }

        public void DeleteFromNames(string username, string rolename)
        {
            DAO<UserRoleDAO, UserRole>.ExecuteNonQuery("DnUserRoleDelete", username, rolename);
        }
    }
}