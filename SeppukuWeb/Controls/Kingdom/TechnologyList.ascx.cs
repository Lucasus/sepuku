using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_Kingdom_TechnologyList : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GvTechnologies_SelectedIndexChanged(object sender, EventArgs e)
    {
        PnlTechnology.Visible = true;
        ASP.controls_kingdom_technology_ascx UcTechnology = 
            (ASP.controls_kingdom_technology_ascx)PnlTechnology.FindControl("UcTechnology");
        UcTechnology.TechnologyId = (int)GvTechnologies.SelectedValue;
        UcTechnology.DataBind();
    }
}
