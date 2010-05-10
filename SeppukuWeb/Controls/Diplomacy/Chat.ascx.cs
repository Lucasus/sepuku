using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_Diplomacy_Opponent : System.Web.UI.UserControl
{

    public int DiplomacyID
    {
        get { return (ViewState[this.ID + "_diplomacyId"] != null) ? (int)ViewState[this.ID + "_diplomacyId"] : 0; }
        set { ViewState[this.ID + "_diplomacyId"] = value; }
    }

    public override void DataBind()
    {
        OdsMessage.SelectParameters.Clear();
        OdsMessage.SelectParameters.Add("diplomacyId", DiplomacyID.ToString());
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
        // e.InputParameters["TechnologyId"] = TechnologyId;
    }



    protected void Click_SendMessage(object sender, EventArgs e)
    {
        Seppuku.Domain.Message mgs = new Seppuku.Domain.Message();
        mgs.MainUserId = Seppuku.Core.CurrentUser.UserId;
        mgs.SecondaryUserId = new Seppuku.Services.DiplomacyService().GetById(DiplomacyID).SecondaryUserId;
        mgs.Text = TextBox1.Text;
        new Seppuku.Services.MessageService().Add(mgs);
        this.DataBind(); 
    }
}