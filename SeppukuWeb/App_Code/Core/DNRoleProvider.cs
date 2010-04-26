using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using DN.Domain;
using DN.DAO;

namespace DN.Core
{
    public class DNRoleProvider: SqlRoleProvider
    {
        public override string[] GetAllRoles()
        {
            IList<Role> role = new RoleDAO().GetAll();
            string[] rs = new string[role.Count];
            for (int i = 0; i < rs.Length; i++)
            {
                rs[i] = role[i].RoleName;
            }
            return rs;
        }

        public override string[] GetRolesForUser(string username)
        {
            RoleDAO rd = new RoleDAO();
            IList<Role> role = rd.GetByUserName(username); 
            string[] rs = new string[role.Count];
            for(int i=0;i<rs.Length;i++)
            {
                rs[i] = role[i].RoleName;
            }
            return rs;
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            RoleDAO rd = new RoleDAO();
            IList<Role> roles = rd.GetByUserName(username);
            foreach (Role r in roles)
            {
                if (r.RoleName == roleName)
                    return true;
            }
            return false;
        }

        public override void AddUsersToRoles(string[] userNames, string[] roleNames)
        {
            UserRoleDAO roleDao = new UserRoleDAO();
            foreach (string username in userNames)
            {
                foreach (string rolename in roleNames)
                {
                    roleDao.AddFromNames(username, rolename);
                }
            }
        }

        public override void RemoveUsersFromRoles(string[] userNames, string[] roleNames)
        {
            UserRoleDAO roleDao = new UserRoleDAO();
            foreach (string username in userNames)
            {
                foreach (string rolename in roleNames)
                {
                    roleDao.DeleteFromNames(username, rolename);
                }
            }
        }
    }
}
