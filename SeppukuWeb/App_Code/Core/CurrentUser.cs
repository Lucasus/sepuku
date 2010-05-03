using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using Seppuku.Domain;
using Seppuku.DAO;

namespace Seppuku.Core
{
    public class CurrentUser : IHttpModule
    {
        public void Init(HttpApplication application)
        {
            application.AcquireRequestState += new EventHandler(application_AuthenticateRequest);
        }

        private void application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpContext context = System.Web.HttpContext.Current;
            if (context.Request.IsAuthenticated)
            {
                if (context.Session != null)
                {
                    if (context.Session["CurrentUser"] == null || (context.Session["UserId"] == null
                        || (int)context.Session["UserId"] == 0))
                    {
                        LoadCurrentUser(context.User.Identity.Name, context);
                    }

                }
            }
        }
        public static void LoadCurrentUser(string userName, HttpContext context)
        {
            User User = (new UserDAO()).GetByUserName(userName, null);

            context.Session.Add("CurrentUser", User);
            context.Session.Add("UserId", User.UserId);

            IList<Role> roles = new RoleDAO().GetByUserId(User.UserId);

            Dictionary<string, int> roleNames = new Dictionary<string, int>();
            foreach (Role role in roles)
            {
                if (roleNames.ContainsKey(role.RoleName.ToLower()) == false)
                {
                    roleNames.Add(role.RoleName.ToLower(), role.RoleId);
                }
            }
            context.Session.Add("UserRoles", roleNames);
        }

        public static Dictionary<string, int> Roles
        {
            get { return System.Web.HttpContext.Current.Session["UserRoles"] as Dictionary<string, int>; }
        }

        public static bool IsInRole(string rolaNazwa)
        {
            return Roles.ContainsKey(rolaNazwa.ToLower());
        }

        public static int UserId
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["UserId"] != null)
                {
                    return (int)System.Web.HttpContext.Current.Session["UserId"];
                }
                return 0;
            }
        }

        public static User Current
        {
            get
            {
                if (System.Web.HttpContext.Current.Session != null)
                {
                    return (User)System.Web.HttpContext.Current.Session["CurrentUser"];
                }
                return new User();
            }
        }
        public static void CurrentUserReset()
        {

            System.Web.HttpContext.Current.Session.Remove("CurrentUser");
            System.Web.HttpContext.Current.Session.Remove("UserId");
            System.Web.HttpContext.Current.Session.Remove("UserRoles");
        }

        public void Dispose()
        {
        }


    }
}