using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Seppuku.Services;
using Seppuku.Core;

public partial class ActivateUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            if(!String.IsNullOrEmpty(Request["userName"])
               && !String.IsNullOrEmpty(Request["Id"]))
            {
                string userName = Request["userName"];
                string authorizationKey = Request["Id"];

                CommandStatus status = new CommandStatus();
                new UsersService().AuthorizeUser(userName, authorizationKey, status);
                if (status.IsError == false)
                    LblResult.Text = "Twoje konto zostało aktywowane. Możesz zalogować się na stronę.";
                else switch (status.Message)
                {
                    case "Invalid UserName":
                        LblResult.Text = "Link aktywacyjny niepoprawny. Błędna nazwa użytkownika";
                        break;
                    case "Invalid Authentication Key":
                        LblResult.Text = "Link aktywacyjny niepoprawny. Błędny klucz aktywacyjny";
                        break;
                    case "Already Approved":
                        LblResult.Text = "Użytkownik został już wcześniej aktywowany. Możesz zalogować się na swoje konto";
                        break;
                }

            }
        }
    }
}
