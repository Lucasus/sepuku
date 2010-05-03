using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_Kingdom_Technology : System.Web.UI.UserControl
{
    public int TechnologyId
    {
        get { return (ViewState[this.ID + "_technologyId"] != null) ? (int)ViewState[this.ID + "_technologyId"] : 0; }
        set { ViewState[this.ID + "_technologyId"] = value; }
    }

    public override void DataBind()
    {
        OdsTechnology.SelectParameters.Clear();
        OdsTechnology.SelectParameters.Add("technologyId", TechnologyId.ToString());
        base.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.DataBind();
        }
    }
    protected void OdsTechnology_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
       // e.InputParameters["TechnologyId"] = TechnologyId;
    }
}
