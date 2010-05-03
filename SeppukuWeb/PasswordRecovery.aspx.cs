using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PasswordRecovery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["key"] != null)
        {
            UcChangePassword.Visible = true;
            UcSendMail.Visible = false;
        }
        else
        {
            UcChangePassword.Visible = false;
            UcSendMail.Visible = true;
        }
    }
}
