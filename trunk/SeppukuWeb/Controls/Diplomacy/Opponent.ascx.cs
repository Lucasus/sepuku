using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_Diplomacy_Opponent : System.Web.UI.UserControl
{

    public int DiplomacyId
    {
        get { return (ViewState[this.ID + "_diplomacyId"] != null) ? (int)ViewState[this.ID + "_diplomacyId"] : 0; }
        set { ViewState[this.ID + "_diplomacyId"] = value; }
    }

    public override void DataBind()
    {
        OdsDiplomacy.SelectParameters.Clear();
        OdsDiplomacy.SelectParameters.Add("diplomacyId", DiplomacyId.ToString());
        base.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.DataBind();
        }
    }

    protected void OdsDiplomacy_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        
    }
}