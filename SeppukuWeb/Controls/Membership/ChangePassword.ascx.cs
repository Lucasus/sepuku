using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seppuku.Services;
using System.Web.Security;
using Seppuku.Core;
using Seppuku.Domain;

public partial class Controls_Membership_ChangePassword : System.Web.UI.UserControl
{
    UserService service = new UserService();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Email.Text = CurrentUser.Current.Email;
        }
    }

    protected void CvPassword_ServerValidate(Object source, ServerValidateEventArgs args)
    {
        string password = args.Value;
        if (Membership.ValidateUser(CurrentUser.Current.UserName, password))
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }
    protected void ContinueButton_Click(object sender, EventArgs e)
    {
        bool pass1Empty = String.IsNullOrEmpty(NewPassword.Text);
        bool pass2Empty = String.IsNullOrEmpty(NewPasswordConfirm.Text);
        if (pass1Empty && !pass2Empty || !pass1Empty && pass2Empty)
        {
            CmpConfirmPassword.IsValid = false;
        }
        else
        {
            User user = CurrentUser.Current;
            user.Password = NewPassword.Text;
            user.Email = Email.Text;
            service.Update(user);
            Message.Text = "Dane zostały zmienione";
        }
    }
}
