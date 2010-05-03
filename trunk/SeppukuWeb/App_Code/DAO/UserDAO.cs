using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Seppuku.Domain;
using Seppuku.Core;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace Seppuku.DAO
{

    public class UserDAO : IDAO<User>
    {
        public User DataObject { get; set; }

        public int Add(User user)
        {
            DataObject = user;
            return DAO<UserDAO, User>.Add("DnUserAdd", this);
        }

        public void Update(User user)
        {
            DataObject = user;
            DAO<UserDAO, User>.Update("DnUserUpdate", this);
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

        public void ChangePasswordWithKey(string key, string password)
        {
            DAO<UserDAO, User>.ExecuteNonQuery("DnUserChangePasswordWithKey", key, password);
        }

        public bool ValidateChangePasswordKey(string changePasswordKey)
        {
            return Convert.ToBoolean(DAO<UserDAO, User>.ExecuteScalar("DnUserChangePasswordKeyValidate", changePasswordKey));
        }

        public int AddChangePasswordKey(int userId, Guid key)
        {
            return Convert.ToInt32(DAO<UserDAO, User>.ExecuteScalar("DnUserChangePasswordAdd", userId, key.ToString()));
        }

        public void FillParametersFromProperties(Database db, ref DbCommand cmd)
        {
            if (this.DataObject.UserId > 0)
            {
                db.AddInParameter(cmd, "UserId", DbType.Int32, this.DataObject.UserId);
            }
            db.AddInParameter(cmd, "UserName", DbType.String, this.DataObject.UserName);
            db.AddInParameter(cmd, "Email", DbType.String, this.DataObject.Email);
            if (this.DataObject.AuthorizatonKey != null && this.DataObject.AuthorizatonKey != Guid.Empty)
            {
                db.AddInParameter(cmd, "AuthorizationKey", DbType.String, this.DataObject.AuthorizatonKey.ToString());
            }

            if (!String.IsNullOrEmpty(this.DataObject.PasswordHash))
            {
                db.AddInParameter(cmd, "Password", DbType.String, this.DataObject.PasswordHash);
            }
            else
            {
                db.AddInParameter(cmd, "Password", DbType.String, DBNull.Value);
            }

            if (this.DataObject.CreateDate != null && this.DataObject.CreateDate != new DateTime())
            {
                db.AddInParameter(cmd, "CreateDate", DbType.DateTime, this.DataObject.CreateDate);
            }
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