using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seppuku.Services;

public partial class Controls_Membership_RecoveryChangePassword : System.Web.UI.UserControl
{
    private UserService service = new UserService();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ContinueButton_Click(object sender, EventArgs e)
    {
        if (Request["key"] != null && service.ValidateChangePasswordKey(Request["key"]))
        {
            string pass = Password.Text;
            string key = Request["key"];

            service.ChangePasswordWithKey(key, pass);

            TableBefore.Visible = false;
            TableAfter.Visible = true;
        }
        else
        {
            Message.Text = "Link jest niepoprawny";
        }
    }
}
