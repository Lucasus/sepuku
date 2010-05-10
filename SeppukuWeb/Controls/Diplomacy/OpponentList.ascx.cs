using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_Diplomacy_OpponentList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GvOpponents_SelectedIndexChanged(object sender, EventArgs e)
    {
        PnlOpponent.Visible = true;
        ASP.controls_diplomacy_chat_ascx UcOpponent =
            (ASP.controls_diplomacy_chat_ascx)PnlOpponent.FindControl("UcOpponent");
        UcOpponent.DiplomacyID = (int)GvOpponents.SelectedValue;
        UcOpponent.DataBind();
    }

}