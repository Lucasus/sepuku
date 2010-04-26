using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DN.Domain;
using DN.Core;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace DN.DAO
{

    public class UserDAO : IDAO<User>
    {
        public User DataObject { get; set; }

        public int Add(User user)
        {
            DataObject = user;
            return DAO<UserDAO, User>.Add("DnUserAdd", this);
        }

        public User GetByUserName(string userName, CommandStatus status)
        {
            return DAO<UserDAO, User>.GetSingleObject("DnUserGetByLogin", status, userName);
        }

        public User GetByUserEmail(string email)
        {
            return DAO<UserDAO, User>.GetSingleObject("DnUserGetByEmail", email);
        }

        public IList<User> GetAll()
        {
            return DAO<UserDAO, User>.GetObjectList("DnUserGetAll");
        }

        public int GetUsersCount()
        {
            return Convert.ToInt32(DAO<UserDAO, User>.ExecuteScalar("DnUserCount"));
        }

        public bool ValidateUser(string userName, string passwordHash)
        {
            return Convert.ToBoolean(DAO<UserDAO, User>.ExecuteScalar("DnUserValidate", userName, passwordHash));
        }

        public bool Authorize(string userName, string authorizationKey, CommandStatus status)
        {
            return Convert.ToBoolean(DAO<UserDAO, User>.ExecuteScalar("DnUserAuthorize", status, userName, authorizationKey));
        }

        public void FillParametersFromProperties(Database db, ref DbCommand cmd)
        {
            if (this.DataObject.UserId > 0)
            {
                db.AddInParameter(cmd, "UserId", DbType.Int32, this.DataObject.UserId);
            }
            db.AddInParameter(cmd, "UserName", DbType.String, this.DataObject.UserName);
            db.AddInParameter(cmd, "Email", DbType.String, this.DataObject.Email);
            db.AddInParameter(cmd, "AuthorizationKey", DbType.String, this.DataObject.AuthorizatonKey.ToString());
            db.AddInParameter(cmd, "Password", DbType.String, this.DataObject.PasswordHash);
            db.AddInParameter(cmd, "CreateDate", DbType.DateTime, this.DataObject.CreateDate);
        }

        public User GetFromRow(DataRow dr)
        {
            User obj = new User();
            obj.UserId = Helper.GetData<int>(dr, "UserId");
            obj.UserName = Helper.GetData<string>(dr, "UserName");
            obj.CreateDate = Helper.GetData<DateTime>(dr, "CreateDate");
            obj.Email = Helper.GetData<string>(dr, "Email");
            string guid = Helper.GetData<string>(dr, "KeyGuid");
            if (String.IsNullOrEmpty(guid))
                obj.AuthorizatonKey = Guid.Empty;
            else
                obj.AuthorizatonKey = new Guid(guid);
            return obj;
        }
    }
}