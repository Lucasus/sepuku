using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seppuku.Domain;
using Seppuku.Services;

public partial class Kingdom_Page : RestrictedUserPage
{
    protected override void Page_Load(object sender, EventArgs e)
    {
        //DataBind();   
    }

    protected void UcTechnologyList_Changed(object sender, EventArgs e)
    {
        UcKingdomSummary.DataBind();
    }

    public override void DataBind()
    {
        base.DataBind();
    }

}
