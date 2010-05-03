using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Seppuku.Domain;
using Seppuku.Services;
using System.Text;
using System.Net.Mail;

public partial class Controls_Membership_RecoverySendMail : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ContinueButton_Click(object sender, EventArgs e)
    {
        UserService service = new UserService();

        string emailAddress = Email.Text;
        User user = service.GetByEmail(emailAddress);
        if (user != null && user.UserId != 0)
        {
            Guid key = Guid.NewGuid();
            int keyId = service.NewChangePasswordKey(user.UserId, key);
            if (keyId != 0)
            {
                string appBaseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + '/';

                // Now lets create an email message
                StringBuilder emailMessage = new StringBuilder();
                emailMessage.Append("Dzień dobry,");
                emailMessage.Append("<br /><br />");
                emailMessage.Append("Dostałeś tego maila, ponieważ aktywowałeś przypomnienie loginu i hasła do Twojego konta.");
                emailMessage.Append("<br /><br />");
                emailMessage.Append("Twój login to: " + user.UserName + "<br />");
                emailMessage.Append("<br />");
                emailMessage.Append(string.Format("Kliknij <a href='" + appBaseUrl + "PasswordRecovery.aspx?key={1}'> tutaj </a> aby zmienić hasło do swojego konta.",
                    user.UserName, key.ToString()));
                emailMessage.Append("<br /><br />");
                emailMessage.Append("Pozdrawia");
                emailMessage.Append("<br />");
                emailMessage.Append("Zespół dobre-nawyki.pl");

                MailMessage email = new MailMessage();
                email.From = new MailAddress("noReply@lukaszwiatrak.pl");
                email.To.Add(new MailAddress(emailAddress));
                email.Subject = "[dobre-nawyki.pl] Przypomnienie hasła";
                email.Body = emailMessage.ToString();
                email.IsBodyHtml = true;

                // Send the email
                SmtpClient client = new SmtpClient();
                client.Send(email);

                TableBefore.Visible = false;
                TableAfter.Visible = true;
            }
        }
    }
}
