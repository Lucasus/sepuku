#region Using

using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Net.Mail;

#endregion

public partial class Register : System.Web.UI.Page
{
 
	protected void Page_Load(object sender, EventArgs e)
	{
	}

    protected void RegistrationWizard_CreatedUser(object sender, EventArgs e)
    {
        string userName = RegistrationWizard.UserName;
        string emailAddress = RegistrationWizard.Email;

        //// Lets get the user's id
        MembershipUser user = Membership.GetUser(userName);
        Guid userId = (Guid)user.ProviderUserKey;

        //// Now lets create an email message
        StringBuilder emailMessage = new StringBuilder();
        emailMessage.Append("Dziękujemy za stworzenie konta w seppuku.pl");
        emailMessage.Append("<br />");
        string appBaseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + '/';
        emailMessage.Append(string.Format("Kliknij <a href='" + appBaseUrl + "ActivateUser.aspx?userName={0}&Id={1}'> tutaj </a> aby dokończyć proces rejestracji.", 
            userName, userId.ToString()));
                
        MailMessage email = new MailMessage();
        email.From = new MailAddress("noReply@lukaszwiatrak.pl");
        email.To.Add(new MailAddress(emailAddress));
        email.Subject = "Prośba o aktywację konta w seppuku.pl";
        email.Body = emailMessage.ToString();
        email.IsBodyHtml = true;

        // Send the email
        SmtpClient client = new SmtpClient();
        client.Send(email);

    }
    protected void RegistrationWizard_CreatingUser(object sender, LoginCancelEventArgs e)
    {
    }
    protected void CvRegulamin_ServerValidate(Object source, ServerValidateEventArgs args)
    {
        CheckBox CkbRegulamin = (CheckBox)RegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("CkbRegulamin");
        if (CkbRegulamin.Checked == false)
        {
            args.IsValid = false;
            //Literal ErrorMessage = (Literal)RegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("ErrorMessage");
            //ErrorMessage.Text = "Do ukończenia rejestracji wymagana jest akceptacja regulaminu";
            //ErrorMessage.Visible = true;
            //e.Cancel = true;
        }

        //args.IsValid = (CheckBox1.Checked == true);
    }
}
