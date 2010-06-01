using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seppuku.Domain;
using Seppuku.Services;

public partial class Controls_Kingdom_KingdomSummary : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataBind();
    }

    public override void DataBind()
    {
        Kingdom k = new KingdomService().GetInfo();
        LblKingdomArmy.Text = k.KingdomArmy.ToString();
        LblKingdomResources.Text = k.KingdomResources.ToString();
        LblKingdomSize.Text = k.KingdomSize.ToString();
        base.DataBind();
    }
}
