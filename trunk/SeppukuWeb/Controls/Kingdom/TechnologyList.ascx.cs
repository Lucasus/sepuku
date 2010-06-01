using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seppuku.Services;
using Seppuku.Core;

public partial class Controls_Kingdom_TechnologyList : System.Web.UI.UserControl
{
    public delegate void EventHandler(object sender, EventArgs e);
    public event EventHandler TechnologyListChanged; 

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
    protected void GvTechnologies_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Buy"))
        {
            string s = GvTechnologies.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["TechnologyId"].ToString();
            new TechnologyService().Buy(CurrentUser.KingdomId, Convert.ToInt32(s));
            GvTechnologies.DataBind();
            if (this.TechnologyListChanged != null)
            {
                TechnologyListChanged(this, new EventArgs());
            }

        }
    }
    protected void GvTechnologies_PreRender(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GvTechnologies.Rows)
        {
            LinkButton link = (LinkButton)row.Cells[2].FindControl("BtnTechnologyBuy");
            Label label = (Label)row.Cells[2].FindControl("LblStatus");

            if (label.Text.Equals("Dostepny"))
                label.Visible = false;
            else
                link.Visible = false;
        }
    }
}
