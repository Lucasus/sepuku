using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
	    if(this.User.Identity.IsAuthenticated)
	    {
		    Response.Redirect("Kingdom.aspx");
	    }
	    else 
	    {
		    Response.Redirect("Login.aspx");
	    }
        //HtmlGenericControl body = (HtmlGenericControl)Page.Master.FindControl("pageBody");
        //body.Attributes.Add("onload", "init()");
    }
}
