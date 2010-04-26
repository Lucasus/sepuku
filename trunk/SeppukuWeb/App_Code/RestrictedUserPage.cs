using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public abstract class RestrictedUserPage: System.Web.UI.Page
{
	protected virtual void Page_Load(object sender, EventArgs e)
	{
		if(!this.User.Identity.IsAuthenticated)
		{
			Response.Redirect("Login.aspx");
		}
	}
}
